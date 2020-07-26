using System;
using System.Linq;
using System.Text;
using HexCS.Data.Generation.CSharp;
using HexUN.Data;
using HexCS.Core;
using System.Collections.Generic;

namespace HexUN.Patterns
{
    [Serializable]
    public class ControlViewGenerationToken
    {
        /// <summary>
        /// Namespaces the types in this ControlView depend on
        /// </summary>
        public string[] Namespaces;

        /// <summary>
        /// The namespace this ControlView is contained in
        /// </summary>
        public string Namespace;

        /// <summary>
        /// Name of the control view
        /// </summary>
        public string Name;
        
        /// <summary>
        /// Data managed by the control view
        /// </summary>
        public string[] Data;

        /// <summary>
        /// The commands required by the control
        /// </summary>
        public CommandGenerationToken[] Commands;

        public string ProviderInterfaceName => $"I{Name}Provider";
        public string ProviderFieldGenericName => $"_{Name.EnforceFirstCharLowerCase()}ProviderGeneric";
        public string ProviderFieldConcreteName => $"_{Name.EnforceFirstCharLowerCase()}Provider";

        public string ControlInterfaceName => $"I{Name}Control";
        public string ControlBaseName => $"A{Name}Control";

        public string ViewBaseName => $"A{Name}View";

        public string EventListenerName => $"{Name}ProviderEventListener";
        public string EventListenerProviderObjectVar => $"_{Name.EnforceFirstCharLowerCase()}ProviderObject";
        public string EventListenerProviderVar => $"_{Name.EnforceFirstCharLowerCase()}Provider";







        public string DataEventSubscriberName(string Name) => $"On{Name}";
        public string DataEventSubscriberHandlerName(string Name) => $"Handle{Name}";

        public string DataFunctionName(string Name) => Name;


        public string DataReliableEventName(string Name) => $"_on{Name}";

        public string DataUnityEventVar(string Name) => $"_on{Name}Event";




        /// <summary>
        /// Generates the provider interface at the provided path
        /// </summary>
        /// <param name="sb"></param>
        /// <param name="path"></param>
        public void GenerateProviderInterface(StringBuilder sb, UnityPath path)
        {
            using (GTFile f = new GTFile(sb, path.Path.AddStep($"{ProviderInterfaceName}.cs"), Encoding.Default))
            {
                List<string> usings = new List<string>() { "HexUN.Patterns" };
                usings.AddRange(Namespaces);

                f.Generate_Usings<GTUsings>().SetRequired(usings.Distinct().ToArray());
                
                using (GTNamespace n = f.Generate_Namespace<GTNamespace>())
                {
                    n.SetRequired(Namespace);

                    using (GTInterface i = n.Generate_NamespaceObject<GTInterface>())
                    {
                        i.SetRequired(ProviderInterfaceName, EKeyword.PUBLIC);

                        foreach(string t in Data)
                        {
                            i.Generate_Definition<GTInterfaceDefinition_Property>()
                                .SetRequired(
                                    "IEventSubscriber<CVCommand>",
                                    DataEventSubscriberName(t),
                                    true,
                                    false
                                );
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Generates the control interface
        /// </summary>
        /// <param name="sb"></param>
        /// <param name="path"></param>
        public void GenerateControlInterface(StringBuilder sb, UnityPath path)
        {
            using (GTFile f = new GTFile(sb, path.Path.AddStep($"{ControlInterfaceName}.cs"), Encoding.Default))
            {
                f.Generate_Usings<GTUsings>().SetRequired(Namespaces);

                using (GTNamespace n = f.Generate_Namespace<GTNamespace>())
                {
                    n.SetRequired(Namespace);

                    using (GTInterface i = n.Generate_NamespaceObject<GTInterface>())
                    {
                        i.SetRequired(ControlInterfaceName, EKeyword.PUBLIC);
                        i.Add_Inheritances(ProviderInterfaceName);

                        foreach (CommandGenerationToken c in Commands)
                        {
                            using (GTInterfaceDefinition_Function id = i.Generate_Definition<GTInterfaceDefinition_Function>())
                            {
                                id.SetRequired("void", c.Name);
                                if (c.Paras != null && c.Paras.Length != 0)
                                {
                                    string[] ps = c.Paras.Split(',');

                                    id.Add_Paramaters(
                                        ps.Select(
                                            pa =>
                                            {
                                                string[] param = pa.Split(' ');
                                                return new Parameter_Basic(param[0].Trim(), param[1].Trim());
                                            }
                                        ).ToArray()
                                    );
                                }
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Generates the base class for control
        /// </summary>
        /// <param name="sb"></param>
        /// <param name="path"></param>
        public void GenerateControlBase(StringBuilder sb, UnityPath path)
        {
            using (GTFile f = new GTFile(sb, path.Path.AddStep($"{ControlBaseName}.cs"), Encoding.Default))
            {
                List<string> usings = new List<string>
                {
                    "UnityEngine",
                    "HexUN.Core.MonoB",
                    "HexUN.Patterns",
                    "HexUN.Core.Events"
                };

                usings.AddRange(Namespaces);

                f.Generate_Usings<GTUsings>().SetRequired(usings.Distinct().ToArray());

                using (GTNamespace n = f.Generate_Namespace<GTNamespace>())
                {
                    n.SetRequired(Namespace);

                    using (GTClass c = n.Generate_NamespaceObject<GTClass>())
                    {
                        c.SetRequired(ControlBaseName, EKeyword.PUBLIC, EKeyword.ABSTRACT);
                        c.Add_Inheritances("AControl", ControlInterfaceName);
                        
                        for(int i = 0; i<Data.Length; i++)
                        {
                            using (GTField fi = c.Generate_Field<GTField>())
                            {
                                if (i == 0)
                                {
                                    using (GTAttribute att = fi.Generate_Attribute<GTAttribute>())
                                    {
                                        att.SetRequired("Header");
                                        att.Add_Args(new Arg_Basic($"\"Emissions ({ControlBaseName})\""));
                                    }
                                }

                                fi.Generate_Attribute<GTAttribute>().SetRequired($"SerializeField");
                                fi.SetRequired("CVCommandReliableEvent", DataReliableEventName(Data[i]), EKeyword.PROTECTED);
                                fi.Generate_DefaultValue<GTValue>().SetRequired($"new CVCommandReliableEvent()");
                            }
                        }

                        for (int i = 0; i < Data.Length; i++)
                        {
                            using (GTProperty_GetOnly fi = c.Generate_Property<GTProperty_GetOnly>())
                            {
                                fi.SetRequired("IEventSubscriber<CVCommand>", DataEventSubscriberName(Data[i]), EKeyword.PUBLIC);
                                fi.Generate_DefaultValue<GTValue>().SetRequired(DataReliableEventName(Data[i]));
                            }
                        }

                        for (int i = 0; i < Commands.Length; i++)
                        {
                            using (GTFunction_Abstract fi = c.Generate_Function<GTFunction_Abstract>())
                            {
                                fi.SetRequired("void", Commands[i].Name, EKeyword.PUBLIC);

                                if(Commands[i].Paras != null && Commands[i].Paras.Length != 0)
                                {
                                    string[] ps = Commands[i].Paras.Split(',');

                                    fi.Add_Paramaters(
                                        ps.Select(
                                            pa =>
                                            {
                                                string[] param = pa.Split(' ');
                                                return new Parameter_Basic(param[0].Trim(), param[1].Trim());
                                            }
                                        ).ToArray()
                                    );
                                }
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Generates the base class for view
        /// </summary>
        /// <param name="sb"></param>
        /// <param name="path"></param>
        public void GenerateViewBase(StringBuilder sb, UnityPath path)
        {
            using (GTFile f = new GTFile(sb, path.Path.AddStep($"{ViewBaseName}.cs"), Encoding.Default))
            {
                List<string> usings = new List<string>
                {
                    "UnityEngine",
                    "HexUN.Core.MonoB",
                    "HexUN.Patterns",
                    "HexUN.Core.Dependencies"
                };

                usings.AddRange(Namespaces);

                f.Generate_Usings<GTUsings>().SetRequired(usings.Distinct().ToArray());

                using (GTNamespace n = f.Generate_Namespace<GTNamespace>())
                {
                    n.SetRequired(Namespace);

                    using (GTClass c = n.Generate_NamespaceObject<GTClass>())
                    {
                        c.SetRequired(ViewBaseName, EKeyword.PUBLIC, EKeyword.ABSTRACT);
                        c.Add_Inheritances("MonoDependent");

                        using (GTField fi = c.Generate_Field<GTField>())
                        {
                            using (GTAttribute att = fi.Generate_Attribute<GTAttribute>())
                            {
                                att.SetRequired("Header");
                                att.Add_Args(new Arg_Basic($"\"Dependencies ({ViewBaseName})\""));
                            }

                            fi.Generate_Attribute<GTAttribute>().SetRequired($"SerializeField");
                            fi.SetRequired("Object", ProviderFieldGenericName, EKeyword.PRIVATE);
                            fi.Generate_DefaultValue<GTValue>().SetRequired("null");
                        }

                        using (GTField fi = c.Generate_Field<GTField>())
                        {
                            fi.SetRequired(ProviderInterfaceName, ProviderFieldConcreteName, EKeyword.PRIVATE);
                        }

                        using (GTFunction_Implementation fi = c.Generate_Function<GTFunction_Implementation>())
                        {
                            fi.SetRequired("void", "ResolveDependencies", EKeyword.PROTECTED, EKeyword.OVERRIDE);

                            fi.Add_Statements(
                                $"UTDependency.Resolve(ref {ProviderFieldGenericName}, out {ProviderFieldConcreteName}, this);"
                            );
                        }

                        using (GTFunction_Implementation fi = c.Generate_Function<GTFunction_Implementation>())
                        {
                            fi.SetRequired("void", "ResolveEventBindings", EKeyword.PROTECTED, EKeyword.OVERRIDE);

                            fi.Add_Parameters(new Parameter_Basic("EventBindingGroup", "ebs"));

                            fi.Add_Statements(
                                Data.Select(
                                    d => 
                                    $"ebs.Add({ProviderFieldConcreteName}.{DataEventSubscriberName(d)}.Subscribe({DataEventSubscriberHandlerName(d)}));").ToArray()
                            );
                        }

                        for (int i = 0; i < Data.Length; i++)
                        {
                            using (GTFunction_Abstract fa = c.Generate_Function<GTFunction_Abstract>())
                            {
                                fa.SetRequired("void", DataEventSubscriberHandlerName(Data[i]), EKeyword.PUBLIC);
                                fa.Add_Paramaters(new Parameter_Basic("CVCommand", "command"));
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Generates the base class for view
        /// </summary>
        /// <param name="sb"></param>
        /// <param name="path"></param>
        public void GenerateEventListenerBase(StringBuilder sb, UnityPath path)
        {
            using (GTFile f = new GTFile(sb, path.Path.AddStep($"{EventListenerName}.cs"), Encoding.Default))
            {
                List<string> usings = new List<string>
                {
                    "UnityEngine",
                    "HexUN.Core.MonoB",
                    "HexUN.Core.Dependencies",
                    "HexUN.Patterns",
                    "HexUN.Core.Events"
                };

                usings.AddRange(Namespaces);

                f.Generate_Usings<GTUsings>().SetRequired(usings.Distinct().ToArray());

                using (GTNamespace n = f.Generate_Namespace<GTNamespace>())
                {
                    n.SetRequired(Namespace);

                    using (GTClass c = n.Generate_NamespaceObject<GTClass>())
                    {
                        c.SetRequired(EventListenerName, EKeyword.PUBLIC);
                        c.Add_Inheritances("MonoDependent");

                        using (GTField fi = c.Generate_Field<GTField>())
                        {
                            fi.Generate_Attribute<GTAttribute>().SetRequired($"SerializeField");
                            fi.SetRequired("Object", EventListenerProviderObjectVar, EKeyword.PRIVATE);
                            fi.Generate_DefaultValue<GTValue>().SetRequired("null");
                        }

                        using (GTField fi = c.Generate_Field<GTField>())
                        {
                            fi.SetRequired(ProviderInterfaceName, ProviderFieldConcreteName, EKeyword.PRIVATE);
                        }

                        for(int i = 0; i<Data.Length; i++)
                        {
                            using (GTField fi = c.Generate_Field<GTField>())
                            {
                                fi.Generate_Attribute<GTAttribute>().SetRequired($"SerializeField");
                                fi.SetRequired("CVCommandUnityEvent", DataUnityEventVar(Data[i]), EKeyword.PRIVATE);
                                fi.Generate_DefaultValue<GTValue>().SetRequired("null");
                            }
                        }

                        using (GTFunction_Implementation fi = c.Generate_Function<GTFunction_Implementation>())
                        {
                            fi.SetRequired("void", "ResolveDependencies", EKeyword.PROTECTED, EKeyword.OVERRIDE);

                            fi.Add_Statements(
                                $"UTDependency.Resolve(ref {EventListenerProviderObjectVar}, out {EventListenerProviderVar}, this, true);"
                            );
                        }

                        using (GTFunction_Implementation fi = c.Generate_Function<GTFunction_Implementation>())
                        {
                            fi.SetRequired("void", "ResolveEventBindings", EKeyword.PROTECTED, EKeyword.OVERRIDE);

                            fi.Add_Parameters(new Parameter_Basic("EventBindingGroup", "ebs"));

                            List<string> statements = new List<string>();
                            statements.Add($"if ({ProviderFieldConcreteName} != null)");
                            statements.Add("{");
                            for (int i = 0; i < Data.Length; i++)
                            {
                                statements.Add($"\tebs.Add({EventListenerProviderVar}.{DataEventSubscriberName(Data[i])}.Subscribe({DataUnityEventVar(Data[i])}.Invoke));");
                            }
                            statements.Add("}");

                            fi.Add_Statements(statements.ToArray());
                        }
                    }
                }
            }
        }
    }
}