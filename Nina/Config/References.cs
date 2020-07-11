using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nina.Config
{
    AppDomain.CurrentDomain.AssemblyResolve += new ResolveEventHandler(CurrentDomain_AssemblyResolve);

    static System.Reflection.Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
    {
        if (/*some condition*/)
            return Assembly.LoadFrom("DifferentDllFolder\\differentVersion.dll");
        else
            return Assembly.LoadFrom("");
    }
}
