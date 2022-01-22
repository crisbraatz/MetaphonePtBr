# MetaphonePtBr

<div>
  <img src="https://img.shields.io/github/license/devcbc/MetaphonePtBr.svg" />
  <img src="https://img.shields.io/github/issues/devcbc/MetaphonePtBr.svg" />
  <img src="https://img.shields.io/github/issues-closed/devcbc/MetaphonePtBr.svg" />
  <img src="https://img.shields.io/github/issues-pr/devcbc/MetaphonePtBr.svg" />
  <img src="https://img.shields.io/github/issues-pr-closed/devcbc/MetaphonePtBr.svg" />
  <img src="https://img.shields.io/nuget/v/MetaphonePtBr" />
  <img src="https://img.shields.io/nuget/dt/MetaphonePtBr" />
</div>

## What is it?

MetaphonePtBr is a text transformation algorithm based on phonetic rules of the Portuguese Brazillian language.

### Credits

This project is a .NET library based on this [C project](https://github.com/carlosjordao/metaphone-ptbr) by [Carlos Costa Jordão](https://github.com/carlosjordao).

## How to use?

First, add the [NuGet package](https://www.nuget.org/packages/MetaphonePtBr/).

Then, on any string:

```csharp
var token = "Word".GetMetaphoneToken();
```

It is just that!

## How is it work?

Basically, the single method generates a token for a single word in a string.

For instance, my name `Cristopher` and the following variations all generates the same `KSF` token:
- Cristofer
- Christopher
- Christofer
- Cristophr
- Cristofr
- Christophr
- Christofr

In other words, the token is the core letters that identify the word by the way it sound.

It can be very useful for searching names, addresses, products, brands and many more when:
- Looking for similar word
- Looking for a specific word, even though it was slightly misspelled

## The algorithm

While iterating through the letters of the word, the algorithm will consider the following elements depending on the current letter:
- The current index
- *The next letter
- *The first letter after the next letter
- *The previous letter
- *The first letter before the previous letter

*If it has.

## The rules

| Symbol | Meaning              |
| :----: | :------------------- |
| Letter | Letter               |
| ˆ      | Begin of the word    |
| $      | End of the word      |
| []     | One occurence of any |
| v      | Any vowel            |
| c      | Any consonant        |
| .      | Any letter           |
| 0      | Bypass               |

_**NOTES**_
- The default rule among all the mutable letters is keep it as it is, so it is not displayed, except when exists a bypass rule
- All the following rules are ordered by priority

### C

| Rule    | Result |
| :-----: | :----- |
| C[AOUc] | K      |
| C[EI]   | S      |
| CHR     | K      |
| CH      | X      |
| C$      | K      |
| Ç       | S      |

### G

| Rule   | Result |
| :----: | :----- |
| G[AOU] | G      |
| G[EI]  | J      |
| GH[EI] | J      |
| GH[c]  | G      |

### H

| Rule  | Result |
| :---: | :----- |
| ˆH[v] | v      |
| H     | 0      |

### Immutables

| Rule  | Result |
| :---: | :----- |
| B     | B      |
| D     | D      |
| F     | F      |
| J     | J      |
| K     | K      |
| M     | M      |
| V     | V      |

### L

| Rule  | Result |
| :---: | :----- |
| L[v]  | v      |
| LH    | 0      |

### N

| Rule  | Result |
| :---: | :----- |
| N$    | M      |
| NH    | 0      |

### P

| Rule  | Result |
| :---: | :----- |
| PH    | F      |

### Q

| Rule  | Result |
| :---: | :----- |
| Q     | K      |

### R

| Rule  | Result |
| :---: | :----- |
| ^R    | 0      |
| R$    | 0      |
| RR    | 0      |

### S

| Rule    | Result |
| :-----: | :----- |
| SH      | X      |
| SC[EI]  | S      |
| SC[AOU] | SK     |
| SCH     | X      |
| S[c]    | S      |

### T

| Rule  | Result |
| :---: | :----- |
| TH    | T      |

### Vowels

| Rule  | Result |
| :---: | :----- |
| ˆ[v]  | v      |

### W

| Rule   | Result |
| :----: | :----- |
| W[LRv] | V      |
| W[c]   | 0      |

### X

| Rule                | Result |
| :-----------------: | :----- |
| X$                  | X      |
| ^EX[v]              | Z      |
| .EX[v]              | X      |
| [CGKLRXv][AIOU]X    | X      |
| [DFMNPQSTVZ][AIOU]X | KS     |
| EX[EI]              | X      |
| EX[CPT]             | S      |
| EX[.]               | KS     |

### Y

| Rule  | Result |
| :---: | :----- |
| Y     | I      |

### Z

| Rule  | Result |
| :---: | :----- |
| Z$    | S      |
