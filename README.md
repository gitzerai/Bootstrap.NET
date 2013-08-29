Bootstrap.NET
=============

Package for easy implementation of Bootstrap (3.0.x+) server-side controls to be used in ASP.NET WebForms.

For my new project I have decided to use Bootstrap from beginning to the end, so I do not have to care
for designs and quickly switch theme later in development for the main controls.

I have realized that Bootstrap controls, and especially it's extended javascript-powered controls, are
getting more and more complicated, modal.js itself has between 10 - 15 lines, tons of Divs, constant
classes, etc. So it becomes p.i.t.a pretty quickly with the page complexity. And since I still like
server-side rendering, and since the compatibility of custom pure html tags is not very good (Hi, x-tags!).

Also it would be nice to have some stuff (like predefined and custom animations) configured server-side
at app_start, etc... have some ideas in my head to extend the Bootstrap capabilities for .NET devs.

Currently I'm writing each webcontrol in the time I need them during the other project development. If you
do not find the control you would like to use, feel me to contact me on honza@babarik.cz and I will be
happy to prepare the WebControl you need.  
