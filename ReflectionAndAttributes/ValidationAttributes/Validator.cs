﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Linq;

namespace ValidationAttributes
{
    public static class Validator
    {
        public static bool IsValid(object obj) 
        {

           PropertyInfo[] properties = obj.GetType().GetProperties();

            foreach  (PropertyInfo property in properties)
            {
                List<MyValidationAttribute> propertyCustomAttributes = property.GetCustomAttributes()
                                                       .Where(x=> x is MyValidationAttribute)
                                                       .Cast<MyValidationAttribute>().ToList();

                foreach (MyValidationAttribute attribute in propertyCustomAttributes)
                {
                    bool result = attribute.IsValid(property.GetValue(obj));

                    if (!result)
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
