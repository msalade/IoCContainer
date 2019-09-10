# IoCContainer

Simple framework which provide container for easier use of [Dependecy Injection](https://en.wikipedia.org/wiki/Dependency_injection) design pattern.

Example of use: 
```c#
var container = new Container();
container.Register<ISample, Sample>();

var myClass = new MyClass(container.GetInstance<ISample>());

```
