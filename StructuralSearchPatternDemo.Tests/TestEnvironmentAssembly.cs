﻿using JetBrains.Application;
using JetBrains.Threading;
using NUnit.Framework;
using System.Collections.Generic;
using System.Reflection;
using StructuralSearchPatternDemo;

/// <summary>
///   Must be in the global namespace.
/// </summary>
[SetUpFixture]
// ReSharper disable CheckNamespace
public class TestEnvironmentAssembly : ReSharperTestEnvironmentAssembly
// ReSharper restore CheckNamespace
{
    /// <summary>
    /// Gets the assemblies to load into test environment.
    /// Should include all assemblies which contain components.
    /// </summary>
    private static IEnumerable<Assembly> GetAssembliesToLoad()
    {
        // Test assembly
        yield return Assembly.GetExecutingAssembly();

        // Plugin code
        yield return typeof(ContainsNullCheckContextAction).Assembly;
    }

    public override void SetUp()
    {
        base.SetUp();
        ReentrancyGuard.Current.Execute(
          "LoadAssemblies",
          () => Shell.Instance.GetComponent<AssemblyManager>().LoadAssemblies(
            GetType().Name, GetAssembliesToLoad()));
    }

    public override void TearDown()
    {
        ReentrancyGuard.Current.Execute(
          "UnloadAssemblies",
          () => Shell.Instance.GetComponent<AssemblyManager>().UnloadAssemblies(
            GetType().Name, GetAssembliesToLoad()));
        base.TearDown();
    }
}