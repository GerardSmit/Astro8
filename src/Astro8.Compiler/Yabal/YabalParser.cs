﻿using Antlr4.Runtime;

namespace Astro8.Yabal;

public partial class YabalParser
{
    protected bool lineTerminatorAhead()
    {
        // Get the token ahead of the current index.
        var possibleIndexEosToken = CurrentToken.TokenIndex - 1;
        var ahead = _input.Get(possibleIndexEosToken);

        if (ahead.Channel != Lexer.Hidden)
        {
            // We're only interested in tokens on the Hidden channel.
            return false;
        }

        if (ahead.Type == LineTerminator)
        {
            // There is definitely a line terminator ahead.
            return true;
        }

        if (ahead.Type == WhiteSpaces)
        {
            // Get the token ahead of the current whitespaces.
            possibleIndexEosToken = CurrentToken.TokenIndex - 2;
            ahead = _input.Get(possibleIndexEosToken);
        }

        // Get the token's text and type.
        string text = ahead.Text;
        int type = ahead.Type;

        // Check if the token is, or contains a line terminator.
        return (type == MultiLineComment && (text.Contains("\r") || text.Contains("\n"))) ||
               (type == LineTerminator);
    }

    protected bool noNewLine()
    {
        // Get the token ahead of the current index.
        var possibleIndexEosToken = CurrentToken.TokenIndex - 1;
        var ahead = _input.Get(possibleIndexEosToken);

        while (ahead.Channel == Lexer.Hidden)
        {
            if (ahead.Type == LineTerminator)
            {
                // There is definitely a line terminator ahead.
                return false;
            }

            ahead = _input.Get(--possibleIndexEosToken);
        }

        return true;
    }
}