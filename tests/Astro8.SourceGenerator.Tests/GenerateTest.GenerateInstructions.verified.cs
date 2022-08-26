﻿//HintName: CpuInstructions.cs
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using System.Runtime.CompilerServices;
using Astro8.Instructions;

namespace Astro8.Devices;

/// <summary>
/// Default instruction set for the Astro-8 CPU.
/// </summary>
public partial class Cpu<THandler>
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private partial void Step(ref StepContext context)
    {
        switch (context.Instruction.Id)
        {
            case 0:
                FETCH(ref context);
                break;
            case 1:
                AIN(ref context);
                break;
            case 2:
                BIN(ref context);
                break;
            case 3:
                CIN(ref context);
                break;
            case 4:
                LDIA(ref context);
                break;
            case 5:
                LDIB(ref context);
                break;
            case 6:
                RDEXP(ref context);
                break;
            case 7:
                WREXP(ref context);
                break;
            case 8:
                STA(ref context);
                break;
            case 9:
                STC(ref context);
                break;
            case 10:
                ADD(ref context);
                break;
            case 11:
                SUB(ref context);
                break;
            case 12:
                MULT(ref context);
                break;
            case 13:
                DIV(ref context);
                break;
            case 14:
                JMP(ref context);
                break;
            case 15:
                JMPZ(ref context);
                break;
            case 16:
                JMPC(ref context);
                break;
            case 17:
                JREG(ref context);
                break;
            case 18:
                LDAIN(ref context);
                break;
            case 19:
                STAOUT(ref context);
                break;
            case 20:
                LDLGE(ref context);
                break;
            case 21:
                STLGE(ref context);
                break;
            case 22:
                LDW(ref context);
                break;
            case 23:
                SWP(ref context);
                break;
            case 24:
                SWPC(ref context);
                break;
            case 25:
                PCR(ref context);
                break;
            case 26:
                BSL(ref context);
                break;
            case 27:
                BSR(ref context);
                break;
            case 28:
                AND(ref context);
                break;
            case 29:
                OR(ref context);
                break;
            case 30:
                NOT(ref context);
                break;
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private void FETCH(ref StepContext context)
    {
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private void AIN(ref StepContext context)
    {
        // Step 2
        {
            // IR
            context.Cpu.Bus = context.Instruction.Data;
            // AW
            context.Cpu.MemoryIndex = context.Cpu.Bus;
        }
        // Step 3
        {
            // RM
            context.Cpu.Bus = context.Get(context.Cpu.MemoryIndex);
            // WA
            context.Cpu.A = context.Cpu.Bus;
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private void BIN(ref StepContext context)
    {
        // Step 2
        {
            // IR
            context.Cpu.Bus = context.Instruction.Data;
            // AW
            context.Cpu.MemoryIndex = context.Cpu.Bus;
        }
        // Step 3
        {
            // RM
            context.Cpu.Bus = context.Get(context.Cpu.MemoryIndex);
            // WB
            context.Cpu.B = context.Cpu.Bus;
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private void CIN(ref StepContext context)
    {
        // Step 2
        {
            // IR
            context.Cpu.Bus = context.Instruction.Data;
            // AW
            context.Cpu.MemoryIndex = context.Cpu.Bus;
        }
        // Step 3
        {
            // RM
            context.Cpu.Bus = context.Get(context.Cpu.MemoryIndex);
            // WC
            context.Cpu.C = context.Cpu.Bus;
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private void LDIA(ref StepContext context)
    {
        // Step 2
        {
            // IR
            context.Cpu.Bus = context.Instruction.Data;
            // WA
            context.Cpu.A = context.Cpu.Bus;
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private void LDIB(ref StepContext context)
    {
        // Step 2
        {
            // IR
            context.Cpu.Bus = context.Instruction.Data;
            // WB
            context.Cpu.B = context.Cpu.Bus;
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private void RDEXP(ref StepContext context)
    {
        // Step 2
        {
            // RE
            context.Cpu.Bus = ExpansionPort;
            // WA
            context.Cpu.A = context.Cpu.Bus;
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private void WREXP(ref StepContext context)
    {
        // Step 2
        {
            // RA
            context.Cpu.Bus = context.Cpu.A;
            // WE
            ExpansionPort = context.Cpu.Bus;
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private void STA(ref StepContext context)
    {
        // Step 2
        {
            // IR
            context.Cpu.Bus = context.Instruction.Data;
            // AW
            context.Cpu.MemoryIndex = context.Cpu.Bus;
        }
        // Step 3
        {
            // RA
            context.Cpu.Bus = context.Cpu.A;
            // WM
            context.Set(context.Cpu.MemoryIndex, context.Cpu.Bus);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private void STC(ref StepContext context)
    {
        // Step 2
        {
            // IR
            context.Cpu.Bus = context.Instruction.Data;
            // AW
            context.Cpu.MemoryIndex = context.Cpu.Bus;
        }
        // Step 3
        {
            // RC
            context.Cpu.Bus = context.Cpu.C;
            // WM
            context.Set(context.Cpu.MemoryIndex, context.Cpu.Bus);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private void ADD(ref StepContext context)
    {
        // Step 2
        {
            // EO
            context.Cpu.FlagA = false;
            context.Cpu.FlagB = false;
        
            // ADD
            context.Cpu.Bus = context.Cpu.A + context.Cpu.B;
            context.Cpu.FlagA = context.Cpu.Bus == 0;

            if (context.Cpu.Bus >= 65534)
            {
                context.Cpu.Bus -= 65534;
                context.Cpu.FlagB = true;
            }
            else
            {
                context.Cpu.FlagB = false;
            }
            // WA
            context.Cpu.A = context.Cpu.Bus;
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private void SUB(ref StepContext context)
    {
        // Step 2
        {
            // EO
            context.Cpu.FlagA = false;
            context.Cpu.FlagB = false;
        
            // SU
            context.Cpu.Bus = context.Cpu.A - context.Cpu.B;
            context.Cpu.FlagA = context.Cpu.Bus == 0;

            if (context.Cpu.Bus < 0)
            {
                context.Cpu.Bus = 65534 + context.Cpu.Bus;
                context.Cpu.FlagB = false;
            }
            else
            {
                context.Cpu.FlagB = true;
            }
            // WA
            context.Cpu.A = context.Cpu.Bus;
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private void MULT(ref StepContext context)
    {
        // Step 2
        {
            // EO
            context.Cpu.FlagA = false;
            context.Cpu.FlagB = false;
        
            // MU
            context.Cpu.Bus = context.Cpu.A * context.Cpu.B;
            context.Cpu.FlagA = context.Cpu.Bus == 0;

            if (context.Cpu.Bus >= 65534)
            {
                context.Cpu.Bus -= 65534;
                context.Cpu.FlagB = true;
            }
            else
            {
                context.Cpu.FlagB = false;
            }
            // WA
            context.Cpu.A = context.Cpu.Bus;
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private void DIV(ref StepContext context)
    {
        // Step 2
        {
            // EO
            context.Cpu.FlagA = false;
            context.Cpu.FlagB = false;
        
            // DI
            if (context.Cpu.B != 0)
            {
                context.Cpu.Bus = context.Cpu.A / context.Cpu.B;
                context.Cpu.FlagA = context.Cpu.Bus == 0;
            }
            else
            {
                context.Cpu.FlagA = false;
                context.Cpu.Bus = 0;
            }

            if (context.Cpu.Bus >= 65534)
            {
                context.Cpu.Bus -= 65534;
                context.Cpu.FlagB = true;
            }
            else
            {
                context.Cpu.FlagB = false;
            }
            // WA
            context.Cpu.A = context.Cpu.Bus;
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private void JMP(ref StepContext context)
    {
        // Step 2
        {
            // CR
            context.Cpu.Bus = context.Cpu.ProgramCounter;
            // AW
            context.Cpu.MemoryIndex = context.Cpu.Bus;
        }
        // Step 3
        {
            // RM
            context.Cpu.Bus = context.Get(context.Cpu.MemoryIndex);
            // J
            context.Cpu.ProgramCounter = context.Cpu.Bus;
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private void JMPZ(ref StepContext context)
    {
        // Step 2
        {
            // CR
            context.Cpu.Bus = context.Cpu.ProgramCounter;
            // AW
            context.Cpu.MemoryIndex = context.Cpu.Bus;
        }
        // Step 3
        {
            // RM
            context.Cpu.Bus = context.Get(context.Cpu.MemoryIndex);
            // CE
            context.Cpu.ProgramCounter += 1;
        }
        // Step 4
        if (context.Cpu.FlagA == false && context.Cpu.FlagB == false)
        {
        }
        // Step 4
        if (context.Cpu.FlagA == false && context.Cpu.FlagB == true)
        {
        }
        // Step 4
        if (context.Cpu.FlagA == true && context.Cpu.FlagB == false)
        {
            // J
            context.Cpu.ProgramCounter = context.Cpu.Bus;
        }
        // Step 4
        if (context.Cpu.FlagA == true && context.Cpu.FlagB == true)
        {
            // J
            context.Cpu.ProgramCounter = context.Cpu.Bus;
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private void JMPC(ref StepContext context)
    {
        // Step 2
        {
            // CR
            context.Cpu.Bus = context.Cpu.ProgramCounter;
            // AW
            context.Cpu.MemoryIndex = context.Cpu.Bus;
        }
        // Step 3
        {
            // RM
            context.Cpu.Bus = context.Get(context.Cpu.MemoryIndex);
            // CE
            context.Cpu.ProgramCounter += 1;
        }
        // Step 4
        if (context.Cpu.FlagA == false && context.Cpu.FlagB == false)
        {
        }
        // Step 4
        if (context.Cpu.FlagA == false && context.Cpu.FlagB == true)
        {
            // J
            context.Cpu.ProgramCounter = context.Cpu.Bus;
        }
        // Step 4
        if (context.Cpu.FlagA == true && context.Cpu.FlagB == false)
        {
        }
        // Step 4
        if (context.Cpu.FlagA == true && context.Cpu.FlagB == true)
        {
            // J
            context.Cpu.ProgramCounter = context.Cpu.Bus;
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private void JREG(ref StepContext context)
    {
        // Step 2
        {
            // RA
            context.Cpu.Bus = context.Cpu.A;
            // J
            context.Cpu.ProgramCounter = context.Cpu.Bus;
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private void LDAIN(ref StepContext context)
    {
        // Step 2
        {
            // RA
            context.Cpu.Bus = context.Cpu.A;
            // AW
            context.Cpu.MemoryIndex = context.Cpu.Bus;
        }
        // Step 3
        {
            // RM
            context.Cpu.Bus = context.Get(context.Cpu.MemoryIndex);
            // WA
            context.Cpu.A = context.Cpu.Bus;
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private void STAOUT(ref StepContext context)
    {
        // Step 2
        {
            // RA
            context.Cpu.Bus = context.Cpu.A;
            // AW
            context.Cpu.MemoryIndex = context.Cpu.Bus;
        }
        // Step 3
        {
            // RB
            context.Cpu.Bus = context.Cpu.B;
            // WM
            context.Set(context.Cpu.MemoryIndex, context.Cpu.Bus);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private void LDLGE(ref StepContext context)
    {
        // Step 2
        {
            // CR
            context.Cpu.Bus = context.Cpu.ProgramCounter;
            // AW
            context.Cpu.MemoryIndex = context.Cpu.Bus;
        }
        // Step 3
        {
            // RM
            context.Cpu.Bus = context.Get(context.Cpu.MemoryIndex);
            // AW
            context.Cpu.MemoryIndex = context.Cpu.Bus;
            // CE
            context.Cpu.ProgramCounter += 1;
        }
        // Step 4
        {
            // RM
            context.Cpu.Bus = context.Get(context.Cpu.MemoryIndex);
            // WA
            context.Cpu.A = context.Cpu.Bus;
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private void STLGE(ref StepContext context)
    {
        // Step 2
        {
            // CR
            context.Cpu.Bus = context.Cpu.ProgramCounter;
            // AW
            context.Cpu.MemoryIndex = context.Cpu.Bus;
        }
        // Step 3
        {
            // RM
            context.Cpu.Bus = context.Get(context.Cpu.MemoryIndex);
            // AW
            context.Cpu.MemoryIndex = context.Cpu.Bus;
            // CE
            context.Cpu.ProgramCounter += 1;
        }
        // Step 4
        {
            // RA
            context.Cpu.Bus = context.Cpu.A;
            // WM
            context.Set(context.Cpu.MemoryIndex, context.Cpu.Bus);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private void LDW(ref StepContext context)
    {
        // Step 2
        {
            // CR
            context.Cpu.Bus = context.Cpu.ProgramCounter;
            // AW
            context.Cpu.MemoryIndex = context.Cpu.Bus;
        }
        // Step 3
        {
            // RM
            context.Cpu.Bus = context.Get(context.Cpu.MemoryIndex);
            // WA
            context.Cpu.A = context.Cpu.Bus;
            // CE
            context.Cpu.ProgramCounter += 1;
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private void SWP(ref StepContext context)
    {
        // Step 2
        {
            // RA
            context.Cpu.Bus = context.Cpu.A;
            // WC
            context.Cpu.C = context.Cpu.Bus;
        }
        // Step 3
        {
            // RB
            context.Cpu.Bus = context.Cpu.B;
            // WA
            context.Cpu.A = context.Cpu.Bus;
        }
        // Step 4
        {
            // RC
            context.Cpu.Bus = context.Cpu.C;
            // WB
            context.Cpu.B = context.Cpu.Bus;
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private void SWPC(ref StepContext context)
    {
        // Step 2
        {
            // RA
            context.Cpu.Bus = context.Cpu.A;
            // WB
            context.Cpu.B = context.Cpu.Bus;
        }
        // Step 3
        {
            // RC
            context.Cpu.Bus = context.Cpu.C;
            // WA
            context.Cpu.A = context.Cpu.Bus;
        }
        // Step 4
        {
            // RB
            context.Cpu.Bus = context.Cpu.B;
            // WC
            context.Cpu.C = context.Cpu.Bus;
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private void PCR(ref StepContext context)
    {
        // Step 2
        {
            // CR
            context.Cpu.Bus = context.Cpu.ProgramCounter;
            // WA
            context.Cpu.A = context.Cpu.Bus;
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private void BSL(ref StepContext context)
    {
        // Step 2
        {
            // EO
            context.Cpu.FlagA = false;
            context.Cpu.FlagB = false;
        
            context.Cpu.Bus = context.Cpu.A << (context.Cpu.B);

            
           if (context.Cpu.Bus == 0)
           {
               context.Cpu.FlagA = true;
           }
           else if (context.Cpu.Bus >= 65534)
           {
               context.Cpu.Bus -= 65534;
               context.Cpu.FlagB = true;
           }
        
            // WA
            context.Cpu.A = context.Cpu.Bus;
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private void BSR(ref StepContext context)
    {
        // Step 2
        {
            // EO
            context.Cpu.FlagA = false;
            context.Cpu.FlagB = false;
        
            context.Cpu.Bus = context.Cpu.A >> (context.Cpu.B);

            
           if (context.Cpu.Bus == 0)
           {
               context.Cpu.FlagA = true;
           }
           else if (context.Cpu.Bus >= 65534)
           {
               context.Cpu.Bus -= 65534;
               context.Cpu.FlagB = true;
           }
        
            // WA
            context.Cpu.A = context.Cpu.Bus;
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private void AND(ref StepContext context)
    {
        // Step 2
        {
            // EO
            context.Cpu.FlagA = false;
            context.Cpu.FlagB = false;
        
            context.Cpu.Bus = context.Cpu.A & context.Cpu.B;

            
           if (context.Cpu.Bus == 0)
           {
               context.Cpu.FlagA = true;
           }
           else if (context.Cpu.Bus >= 65534)
           {
               context.Cpu.Bus -= 65534;
               context.Cpu.FlagB = true;
           }
        
            // WA
            context.Cpu.A = context.Cpu.Bus;
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private void OR(ref StepContext context)
    {
        // Step 2
        {
            // EO
            context.Cpu.FlagA = false;
            context.Cpu.FlagB = false;
        
            context.Cpu.Bus = context.Cpu.A | context.Cpu.B;

            
           if (context.Cpu.Bus == 0)
           {
               context.Cpu.FlagA = true;
           }
           else if (context.Cpu.Bus >= 65534)
           {
               context.Cpu.Bus -= 65534;
               context.Cpu.FlagB = true;
           }
        
            // WA
            context.Cpu.A = context.Cpu.Bus;
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private void NOT(ref StepContext context)
    {
        // Step 2
        {
            // EO
            context.Cpu.FlagA = false;
            context.Cpu.FlagB = false;
        
            context.Cpu.Bus = ~context.Cpu.A;

            
           if (context.Cpu.Bus == 0)
           {
               context.Cpu.FlagA = true;
           }
           else if (context.Cpu.Bus >= 65534)
           {
               context.Cpu.Bus -= 65534;
               context.Cpu.FlagB = true;
           }
        
            // WA
            context.Cpu.A = context.Cpu.Bus;
        }
    }

}
