using EmployeePortal.Builder.IBuilder;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;

namespace EmployeePortal.Builder.Director
{
    public class ConfigurationBuilder
    {
        public void BuildSystem(ISystemBuilder systemBuilder, NameValueCollection collection)
        {
            systemBuilder.AddDriver(collection["Drive"]);
            systemBuilder.AddMemory(collection["Memory"]);
            systemBuilder.AddKeyoard(collection["Keyboard"]);
            systemBuilder.AddMouse(collection["Mouse"]);
            systemBuilder.AddTouchScreen(collection["Touchscreen"]);

        }
    }
}