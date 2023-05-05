Advent of code basic C\# setup project
======================================

This progam is intended to be used as a base for solving Advent of Code problems
in C\#.

Advent of Code links
--------------------

<https://adventofcode.com/2015>

<https://adventofcode.com/2016>

<https://adventofcode.com/2017>

<https://adventofcode.com/2018>

<https://adventofcode.com/2019>

<https://adventofcode.com/2020>

<https://adventofcode.com/2021>

<https://adventofcode.com/2022>

 

About
=====

This is a basic C\# solution for setting up an environment for solving Advent of
Code problems and skipping the required boilerplate.

 

Setup
=====

This solution contains a project that can be used for skipping all the
boilerplate of setting up Advent of Code problems by generating the required
files. The generation consists of 2 parts:

-   Generating the class files; you can create a class template and generate the
    same template for all the required Problems.

-   Retrieving input files; Because each login has different input files, the
    process of retrieving and using the input files has been automated based on
    your session key.

 

Step by step
------------

 

1.  Set the Setup project as the startup project.

2.  Look in the Program.cs file of the Setup project, Edit the ClassTemplate
    function as required.

3.  Login into Advent of Code, retrieve the session cookie and put it into the
    SESSIONKEY.TXT file (Session key can be found in the cookies)

4.  Run Setup

5.  All the Class files should be generated and Input files should be retrieved.

 

Doing problems
==============

 

After the setup step has been done, you can start solving problems.

 

Step by step
------------

 

1.  Set Solver as the startup project

2.  Open TARGETS.TXT in the solver project. Put the year and the name of the
    problems you want to solve.  
    Example:  
    2015.1  
    for solving the problem of year 2015 day 1. You can also put multiple days
    in TARGETS.TXT  
    Example:  
    2015.1  
    2016.1  
    2017.22

3.  Edit the class for the problem being solved. You can access the input with
    the raw variable.

4.  Run the Solver Project and see the results.

5.  Change the contents of TARGETS.TXT when you want to run other problems.
