# TOAPI
An extensive C# library for learning how to do P/Invoke against Win32 

Introduction
============

A 'toapi' is a “hat”, or something that covers.  In the case of the TOAPI libraries, it means: 
This Old Application Programming Interface (TOAPI).  

The code here is ancienct code, originally written around 2005 - 2009 timeframe, when the CLR was young, 
and the Windows Runtime wasn't even a glimmer in anyone's eye.  It is a very thin library that gives CLR 
language programmers easy access to common Windows (Win32) APIs.  The Windows Runtime has been born since,
and more than covers what you will find here.

This library was originally designed as a teaching tool so that engineers who are new to the .net programming 
environment, and even to Windows programming, can learn how to do interesting things using CLR languages 
sooner rather than later.

The code was originally located in a private repository, across several projects.  The current
form was pulled out of the public github NewTOAPIA repository.  Why bother resurrecting this code at this
late date?  Although there are myriad teaching aids and resources for C# and the like, I will be 
personally teaching some design and coding courses, and I still find this library to be useful
for that endeavor.  

Disclaimer
----------
Microsoft has created the Windows Runtime, and there is plenty to be found in the .net frameworks. If you 
intend to program Windows using C#, you would be much better served to simply use the SDKs provided 
with the C# language, and platform SDK.  

If your intention is to have your own library to play with, and explore different ways of doing things, 
then this might be a viable tool for you.

Many of the library functions that TOAPI exposes are part of the .net frameworks in one form or another.  
This duplication is deemed to be a good thing by the author as there is a relatively easy transition 
from the easy thin layers presented in TOAPI, to the more robust and complete implementations in the 
.net frameworks.

Design Concepts
---------------

TOAPI has very few, but key, design concepts.

1) Be as close to the raw APIs as possible without introducing a whole new programming model and object libraries.
2) Do not introduce different programming paradigms, such as turning simple return values into exceptions.
3) Simplify the API access by encapsulating esoteric nuances of the API with simplifying calls, where appropriate, but don’t violate 1) above.
4) Very strict layering.  The layering goes from very low level base classes and services to higher structures and functions.  No lower level function or structure depends on a higher level function or structure.

What's in the box
-----------------
TOPI covers significant portions of what has traditionally been thought of as the core of
Win32 programming (Kernel32, GDI32, User32).  In addition it covers some amount of Ole and OleAut.
There is a significant amount of support for OpenGL, which is quite different from the typical support
for DirectXXX APIs.  In addition, there is coverage of the more obsolete Multi Media APIs, like
Video For Windows (vfw).  Lastly, Windows Sockets (Winsock) is covered.  

There are some more obscurities that were added over time as they were needed to support various
higher level programming libraries.  

Building The Thing
------------------
There is a 'build' directory in the library.  This was created using Visual Studio 2019.  Simply
open this solution file and 'Build Solution'.  You should end up with a 'bin/Debug' and 'bin/Release'
directories within the build directory.  Therein you should find the '.dll' files that comprise 
the various assemblies of TOAPI.

Usage
-----
The compiled assemblies can be included in any project you so happen to be building.  Sample usage
will be in a separate repository.

Futures
-------
More interop examples will be added as application usage dictates.  There will also be an effort
to somewhat modernize these interop assemblies to take advantage of the 15 years of progress that 
has been made on the CLR since they were first conceived.

A separate project (TOAPIToppers) will create more interesting object abstractions that
leverage these basic bindings.

