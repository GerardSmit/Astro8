using Astro8.Instructions;

namespace Astro8.Yabal.Ast;

public record SwitchItem(List<Expression> Cases, Expression Value);

public record SwitchExpression(SourceRange Range, Expression Value, List<SwitchItem> Items, Expression Default) : Expression(Range)
{
    public override void Initialize(YabalBuilder builder)
    {
        Value.Initialize(builder);

        foreach (var item in Items)
        {
            foreach (var @case in item.Cases)
            {
                @case.Initialize(builder);
            }

            item.Value.Initialize(builder);
        }

        Default.Initialize(builder);
    }

    protected override void BuildExpressionCore(YabalBuilder builder, bool isVoid)
    {
        Value.BuildExpression(builder, isVoid);

        using var tempValue = builder.GetTemporaryVariable();
        builder.StoreA(tempValue);

        var end = builder.CreateLabel();

        foreach (var item in Items)
        {
            var returnValue = builder.CreateLabel();
            var next = builder.CreateLabel();

            foreach (var caseValue in item.Cases)
            {
                caseValue.BuildExpression(builder, isVoid);
                builder.LoadB(tempValue);
                builder.Sub();
                builder.JumpIfZero(returnValue);
                builder.Jump(next);
            }

            builder.Mark(returnValue);
            item.Value.BuildExpression(builder, isVoid);
            builder.Jump(end);
            builder.Mark(next);
        }

        Default.BuildExpression(builder, isVoid);
        builder.Mark(end);
    }

    public override bool OverwritesB => true;

    public override LanguageType Type => Default.Type;

    public override Expression CloneExpression()
    {
        return new SwitchExpression(
            Range,
            Value.CloneExpression(),
            Items.Select(i => new SwitchItem(i.Cases.Select(c => c.CloneExpression()).ToList(), i.Value.CloneExpression())).ToList(),
            Default.CloneExpression()
        );
    }

    public override Expression Optimize()
    {
        var value = Value.Optimize();
        var items = Items.Select(i => new SwitchItem(i.Cases.Select(c => c.Optimize()).ToList(), i.Value.Optimize())).ToList();
        var defaultValue = Default.Optimize();

        if (value is IConstantValue { Value: { } constantValue } &&
            items.All(i => i.Cases.All(c => c is IConstantValue )))
        {
            var item = items.FirstOrDefault(i => i.Cases.Any(c => c is IConstantValue { Value: { } caseValue } && Equals(caseValue, constantValue)));

            if (item is not null)
            {
                return item.Value;
            }

            return defaultValue;
        }

        return this;
    }
}
