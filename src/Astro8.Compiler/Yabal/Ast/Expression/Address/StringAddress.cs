﻿using Astro8.Instructions;

namespace Astro8.Yabal.Ast;

public class StringAddress : IAddress
{
    private StringAddress(string value)
    {
        Value = value;
    }

    public string Value { get; }

    public Either<int, InstructionPointer> Get(YabalBuilder builder) => builder.GetString(Value);

    public int? Length => Value.Length;

    public static IAddress From(string value) => new StringAddress(value);
}