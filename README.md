# TOAPI
An extensive C# library for learning how to do P/Invoke against Win32 

Introduction
============

In Hindi, Toapi means “hat”, or something that covers.  In the context of the TOAPI libraries, it means: This Old Application Programming Interface (TOAPI).  This is ancienct code, originally written in the 2006 timeframe, when the CLR was young, and the Windows Runtime wasn't even a glimmer in anyone's eye.  It is a very thin library that gives CLR language programmers easy access to common Windows APIs.  
First and foremost the library is designed as a teaching tool so that engineers who are new to the .net programming environment, and even to Windows programming, can learn how to do interesting things using CLR languages sooner rather than later.

This library has been pulled out of the NewTOAPIA repository, and resurrected due to a renewed interest in teaching the subject of learning C# from the ground up.  If you intend to program Windows using C#, you would be much better served to simply use the SDKs provided with the C# language as everything done by TOAPI has now been supported by Microsoft itself, and a whole lot more.  If you intention is to have your own library to play with, and explore different ways of doing things, then this might be a viable library for you.

Many of the library functions that TOAPI exposes are part of the .net frameworks in one form or another.  This duplication is deemed to be a good thing by the author as there is a relatively easy transition from the easy thin layers presented in TOAPI, to the more robust and complete implementations in the .net frameworks.

TOAPI has very few, but key, design concepts.

* Be as close to the raw APIs as possible without introducing a whole new programming model and object libraries.
* Do not introduce different programming paradigms, such as turning simple return values into exceptions.
* Simplify the API access by encapsulating esoteric nuances of the API with simplifying calls, where appropriate, but don’t violate 1) above.
* Very strict layering.  The layering goes from very low level bases classes and services to higher structures and functions.  No lower level function or structure depends on a higher level function or structure.

Since TOAPI is all about Platform/Invoke, and interop to standard C libraries in Windows, in some cases a simpler approach might be taken instead of a more performant one.  The library as a whole though, covers most aspects that a typical programmer is likely to come across.  As study material, the library can serve the student well by showing many different examples, particularly of instances where no tool will provide a satisfactory result by default.
