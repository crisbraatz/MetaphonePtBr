# MetaphonePtBr

![License](https://img.shields.io/github/license/crisbraatz/MetaphonePtBr.svg)
![Issues open](https://img.shields.io/github/issues/crisbraatz/MetaphonePtBr.svg)
![Issues closed](https://img.shields.io/github/issues-closed/crisbraatz/MetaphonePtBr.svg)
![Pull requests open](https://img.shields.io/github/issues-pr/crisbraatz/MetaphonePtBr.svg)
![Pull requests closed](https://img.shields.io/github/issues-pr-closed/crisbraatz/MetaphonePtBr.svg)
![NuGet](https://img.shields.io/nuget/v/MetaphonePtBr)
![Downloads](https://img.shields.io/nuget/dt/MetaphonePtBr)

Brazilian Portuguese phonetic matching for .NET. `MetaphonePtBr` converts single words into stable phonetic tokens for name, address, brand, and fuzzy search.

The package targets `netstandard2.0`, so it can be consumed by modern .NET applications while keeping broad compatibility.

## Install

```bash
dotnet add package MetaphonePtBr
```

NuGet package: [MetaphonePtBr](https://www.nuget.org/packages/MetaphonePtBr)

## Usage

Import the namespace and call `GetMetaphoneToken()` on a single Brazilian Portuguese word.

```csharp
using MetaphonePtBr;

string token = "Cristopher".GetMetaphoneToken();
```

## Matching Example

These spelling variations produce the same token, `KRSTF`:

- Christofer
- Christofr
- Christopher
- Christophr
- Cristofer
- Cristofr
- Cristophr

## Common Use Cases

- Name search
- Address search
- Product or brand matching
- Typo-tolerant lookup
- Duplicate detection for words that sound alike

## Input Contract

- Input must be a single word.
- Input must contain letters only.
- Supported accented Brazilian Portuguese letters: `ÁÀÂÃÉÊÍÓÔÕÚÜÇ` and lowercase equivalents.
- Accents may be provided as precomposed characters or combining marks.
- Symbols, digits, spaces, hyphens, apostrophes, ligatures, ordinal indicators, and non-PT-BR letters are rejected.
- The output is a phonetic token, not the original word.

## How It Works

The algorithm reads the normalized word from left to right and applies Brazilian Portuguese phonetic rules. Depending on the current letter, a rule may inspect:

- the current letter
- the previous letter
- the letter before the previous one
- the next letter
- the letter after the next one

Rules are evaluated by priority. If a mutable letter does not match a special rule, it keeps its default sound.

## Rule Reference

### Symbols

| Symbol | Meaning                             |
|:------:|:------------------------------------|
| Letter | Letter                              |
|  `^`   | Beginning of word                   |
|  `$`   | End of word                         |
|  `[]`  | One occurrence of any listed letter |
|  `v`   | Any vowel                           |
|  `c`   | Any consonant                       |
|  `.`   | Any letter                          |
|  `0`   | Bypass                              |

### C

| Rule  | Result |
|:-----:|:-------|
|  CHR  | K      |
|  CH   | X      |
| C[EI] | S      |
| C[QK] | 0      |
|   C   | K      |
|  C$   | K      |
|   Ç   | S      |

### G

| Rule  | Result |
|:-----:|:-------|
| GH[v] | J      |
| GH[c] | GJ     |
| G[EI] | J      |
|   G   | G      |

### H

| Rule  | Result |
|:-----:|:-------|
| ^H[v] | v      |
|   H   | 0      |

### Immutables

| Rule | Result |
|:----:|:-------|
|  B   | B      |
|  D   | D      |
|  F   | F      |
|  J   | J      |
|  K   | K      |
|  M   | M      |
|  V   | V      |

### L

| Rule | Result |
|:----:|:-------|
|  LH  | 0      |
|  ^L  | L      |
| L[v] | L      |
|  L   | 0      |

### N

| Rule | Result |
|:----:|:-------|
|  N$  | M      |
|  NH  | 0      |
|  NN  | 0      |
|  N   | N      |

### P

| Rule | Result |
|:----:|:-------|
|  PH  | F      |
|  P   | P      |

### Q

| Rule | Result |
|:----:|:-------|
|  Q   | K      |

### R

| Rule | Result |
|:----:|:-------|
|  ^R  | 0      |
|  R$  | 0      |
|  RR  | 0      |
| vRv  | R      |
| .Rc  | R      |
| cRv  | R      |

### S

|  Rule   | Result |
|:-------:|:-------|
|   SS    | S      |
|   SH    | X      |
|   vSv   | Z      |
| SC[EI]  | S      |
| SC[AOU] | SK     |
|   SCH   | X      |
|  SC[.]  | S      |
|    S    | S      |

### T

| Rule | Result |
|:----:|:-------|
|  TH  | T      |
|  T   | T      |

### Vowels

| Rule | Result |
|:----:|:-------|
| ^[v] | v      |

### W

| Rule  | Result |
|:-----:|:-------|
| W[v]  | V      |
| W[LR] | V      |
| W[c]  | 0      |
|  W$   | 0      |

### X

|        Rule         | Result |
|:-------------------:|:-------|
|         X$          | X      |
|       ^EX[v]        | Z      |
|       .EX[EI]       | X      |
|      .EX[AOU]       | KS     |
|        EX[C]        | S      |
|       EX[PT]        | S      |
|        EX[.]        | KS     |
|  [vCKGLRX][AIOU]X   | X      |
| [DFMNPQSTVZ][AIOU]X | KS     |
|          X          | X      |

### Y

| Rule | Result |
|:----:|:-------|
|  Y   | I      |

### Z

| Rule | Result |
|:----:|:-------|
|  Z$  | S      |
|  Z   | Z      |

## Credits

This project is based on [metaphone-ptbr](https://github.com/carlosjordao/metaphone-ptbr) by [Carlos Costa Jordao](https://github.com/carlosjordao).
