# MyIoCContainer

MyIoCContainer is a C# library that allows you to create your own IoC Container to understand its working mechanism.

## Features

- Register and resolve dependencies.
- Support registration with constructor parameters.
- Support registration with initialization methods.
- Support registration with initialization properties.

## Installation

To install MyIoCContainer, you can use NuGet:


Or you can clone the source code from GitHub and build it manually:


## Usage

To use MyIoCContainer, you need to register your dependencies and then resolve them. For example:

```csharp
var container = new MyIoCContainer();
container.Register<IService, Service>();
var service = container.Resolve<IService>();


I hope this README.md template will be helpful for your project. If you have any further questions, please don't hesitate to contact me. 😊
