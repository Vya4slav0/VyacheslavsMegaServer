﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.AspNetCore.Mvc.Authorization;

namespace VyacheslavsMegaServer.Service
{
    public class AdminAreaAutorization : IControllerModelConvention
    {
        private readonly string _area;
        private readonly string _policy;

        public AdminAreaAutorization(string area, string policy) 
        {
            _area = area;
            _policy = policy;
        }

        public void Apply(ControllerModel controller)
        {
            if (controller.Attributes.Any(a => a is AreaAttribute &&
            (a as AreaAttribute).RouteValue.Equals(_area, StringComparison.OrdinalIgnoreCase)) ||
            controller.RouteValues.Any(r => r.Key.Equals(_area, StringComparison.OrdinalIgnoreCase) &&
            r.Value.Equals(_area, StringComparison.OrdinalIgnoreCase)))
            {
                controller.Filters.Add(new AuthorizeFilter(_policy));
            }
        }
    }
}
