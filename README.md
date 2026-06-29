# MetaphonePtBr

![License](https://img.shields.io/github/license/crisbraatz/MetaphonePtBr.svg)
![Issues open](https://img.shields.io/github/issues/crisbraatz/MetaphonePtBr.svg)
![Issues closed](https://img.shields.io/github/issues-closed/crisbraatz/MetaphonePtBr.svg)
![Pull requests open](https://img.shields.io/github/issues-pr/crisbraatz/MetaphonePtBr.svg)
![Pull requests closed](https://img.shields.io/github/issues-pr-closed/crisbraatz/MetaphonePtBr.svg)
![NuGet](https://img.shields.io/nuget/v/MetaphonePtBr)
![Downloads](https://img.shields.io/nuget/dt/MetaphonePtBr)

`MetaphonePtBr` is a .NET library that converts a Brazilian Portuguese word into a phonetic token.

This helps match words that sound alike even when they are spelled differently.

## Install

Add the [NuGet package](https://www.nuget.org/packages/MetaphonePtBr) to your project.

## Use

Call `GetMetaphoneToken()` on a single word:

```csharp
string metaphoneToken = "Cristopher".GetMetaphoneToken();
```

## Example

These variations produce the same token, `KSF`:

- Christofer
- Christofr
- Christopher
- Christophr
- Cristofer
- Cristofr
- Cristophr

This is useful for:

- Name search
- Address search
- Product or brand matching
- Typo-tolerant lookups

## Input Rules

- Input must be a single word
- Input must contain letters only
- Accented characters are supported
- The output is a phonetic token, not the original word

## How It Works

The algorithm reads the word letter by letter and applies Brazilian Portuguese phonetic rules.

For each letter, it may look at:

- The current character
- The previous character
- The character before the previous one
- The next character
- The character after the next one

## Rule Reference

### Symbols

| Symbol | Meaning |
|:------:|:--------|
| Letter | Letter |
| `^` | Beginning of the word |
| `$` | End of the word |
| `[]` | One occurrence of any |
| `v` | Any vowel |
| `c` | Any consonant |
| `.` | Any letter |
| `0` | Bypass |

- If a mutable letter does not match a special rule, it keeps its default sound
- Rules are evaluated by priority

### C

| Rule | Result |
|:----:|:-------|
| C[AOUc] | K |
| C[EI] | S |
| CHR | K |
| CH | X |
| C$ | K |
| Ç | S |

### G

| Rule | Result |
|:----:|:-------|
| G[AOU] | G |
| G[EI] | J |
| GH[EI] | J |
| GH[c] | G |

### H

| Rule | Result |
|:----:|:-------|
| ^H[v] | v |
| H | 0 |

### Immutables

| Rule | Result |
|:----:|:-------|
| B | B |
| D | D |
| F | F |
| J | J |
| K | K |
| M | M |
| V | V |

### L

| Rule | Result |
|:----:|:-------|
| L[v] | v |
| LH | 0 |

### N

| Rule | Result |
|:----:|:-------|
| N$ | M |
| NH | 0 |

### P

| Rule | Result |
|:----:|:-------|
| PH | F |

### Q

| Rule | Result |
|:----:|:-------|
| Q | K |

### R

| Rule | Result |
|:----:|:-------|
| ^R | 0 |
| R$ | 0 |
| RR | 0 |

### S

| Rule | Result |
|:----:|:-------|
| SH | X |
| SC[EI] | S |
| SC[AOU] | SK |
| SCH | X |
| S[c] | S |

### T

| Rule | Result |
|:----:|:-------|
| TH | T |

### Vowels

| Rule | Result |
|:----:|:-------|
| ^[v] | v |

### W

| Rule | Result |
|:----:|:-------|
| W[LRv] | V |
| W[c] | 0 |

### X

| Rule | Result |
|:----:|:-------|
| X$ | X |
| ^EX[v] | Z |
| .EX[v] | X |
| [CGKLRXv][AIOU]X | X |
| [DFMNPQSTVZ][AIOU]X | KS |
| EX[EI] | X |
| EX[CPT] | S |
| EX[.] | KS |

### Y

| Rule | Result |
|:----:|:-------|
| Y | I |

### Z

| Rule | Result |
|:----:|:-------|
| Z$ | S |

## Credits

This project is a .NET library based on [metaphone-ptbr](https://github.com/carlosjordao/metaphone-ptbr) by [Carlos Costa Jordao](https://github.com/carlosjordao).
