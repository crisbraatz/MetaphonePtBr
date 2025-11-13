# MetaphonePtBr

![License](https://img.shields.io/github/license/crisbraatz/MetaphonePtBr.svg)
![Issues open](https://img.shields.io/github/issues/crisbraatz/MetaphonePtBr.svg)
![Issues closed](https://img.shields.io/github/issues-closed/crisbraatz/MetaphonePtBr.svg)
![Pull requests open](https://img.shields.io/github/issues-pr/crisbraatz/MetaphonePtBr.svg)
![Pull requests closed](https://img.shields.io/github/issues-pr-closed/crisbraatz/MetaphonePtBr.svg)
![NuGet](https://img.shields.io/nuget/v/MetaphonePtBr)
![Downloads](https://img.shields.io/nuget/dt/MetaphonePtBr)

## What is it?

MetaphonePtBr is a text transformation algorithm based on phonetic rules of the Brazilian Portuguese language.

## How to use?

First, add the [NuGet package](https://www.nuget.org/packages/MetaphonePtBr) to the desired project.

Then, on any string containing a single word:

```csharp
string metaphoneToken = "Word".GetMetaphoneToken();
```

It is just that!

## How it works?

Basically, it gets the metaphone token from the single PT-BR word.

For instance, the name `Cristopher` and the following variations have the same `KSF` metaphone token:

- Christofer
- Christofr
- Christopher
- Christophr
- Cristofer
- Cristofr
- Cristophr

In other words, the metaphone token is the core letters that identify the word by the way it sound.
It can be very useful for searches like names, addresses, products, brands and many more when:

- Looking for similar word
- Looking for a specific word, even though it was slightly misspelled

While iterating through the letters of the word, depending on the current letter, the algorithm considers:

- The current index
- *The next letter
- *The first letter after the next letter
- *The previous letter
- *The first letter before the previous letter

*If there is.

### The rules

| Symbol | Meaning               |
|:------:|:----------------------|
| Letter | Letter                |
|   ˆ    | Begin of the word     |
|   $    | End of the word       |
|   []   | One occurrence of any |
|   v    | Any vowel             |
|   c    | Any consonant         |
|   .    | Any letter            |
|   0    | Bypass                |

- The default rule among all the following mutable letters is to keep it as it is, so this rule has not been mapped, except for bypass cases
- All the following rules are ordered by priority

#### C

|  Rule   | Result |
|:-------:|:-------|
| C[AOUc] | K      |
|  C[EI]  | S      |
|   CHR   | K      |
|   CH    | X      |
|   C$    | K      |
|    Ç    | S      |

#### G

|  Rule  | Result |
|:------:|:-------|
| G[AOU] | G      |
| G[EI]  | J      |
| GH[EI] | J      |
| GH[c]  | G      |

#### H

| Rule  | Result |
|:-----:|:-------|
| ˆH[v] | v      |
|   H   | 0      |

#### Immutables

| Rule | Result |
|:----:|:-------|
|  B   | B      |
|  D   | D      |
|  F   | F      |
|  J   | J      |
|  K   | K      |
|  M   | M      |
|  V   | V      |

#### L

| Rule | Result |
|:----:|:-------|
| L[v] | v      |
|  LH  | 0      |

#### N

| Rule | Result |
|:----:|:-------|
|  N$  | M      |
|  NH  | 0      |

#### P

| Rule | Result |
|:----:|:-------|
|  PH  | F      |

#### Q

| Rule | Result |
|:----:|:-------|
|  Q   | K      |

#### R

| Rule | Result |
|:----:|:-------|
|  ^R  | 0      |
|  R$  | 0      |
|  RR  | 0      |

#### S

|  Rule   | Result |
|:-------:|:-------|
|   SH    | X      |
| SC[EI]  | S      |
| SC[AOU] | SK     |
|   SCH   | X      |
|  S[c]   | S      |

#### T

| Rule | Result |
|:----:|:-------|
|  TH  | T      |

#### Vowels

| Rule | Result |
|:----:|:-------|
| ˆ[v] | v      |

#### W

|  Rule  | Result |
|:------:|:-------|
| W[LRv] | V      |
|  W[c]  | 0      |

#### X

|        Rule         | Result |
|:-------------------:|:-------|
|         X$          | X      |
|       ^EX[v]        | Z      |
|       .EX[v]        | X      |
|  [CGKLRXv][AIOU]X   | X      |
| [DFMNPQSTVZ][AIOU]X | KS     |
|       EX[EI]        | X      |
|       EX[CPT]       | S      |
|        EX[.]        | KS     |

#### Y

| Rule | Result |
|:----:|:-------|
|  Y   | I      |

#### Z

| Rule | Result |
|:----:|:-------|
|  Z$  | S      |

## Credits

This project is a .NET library based on this [project](https://github.com/carlosjordao/metaphone-ptbr) by [Carlos Costa Jordão](https://github.com/carlosjordao).
