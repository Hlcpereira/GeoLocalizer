/**
 * Copyright 2022 - Henrique Pereira/Hlcpereira
 *
 * SPDX-License-Identifier: Apache-2.0
 */

using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using Hlcpereira.GeoLocalizer.Domain.AppServices.Commands;
using Hlcpereira.GeoLocalizer.Domain.AppServices.Contracts;

namespace Hlcpereira.GeoLocalizer.Api.Controllers.V1
{
    [ApiController]
    [ApiExplorerSettings(GroupName = "GeoLocation")]
    [Route("[controller]")]
    public class LocalController : ControllerBase
    {
        private IGeoLocalizationService _geoLocalizationService;

        public LocalController(IGeoLocalizationService geoLocalizationService)
        {
            _geoLocalizationService = geoLocalizationService;
        }

        [HttpPost]
        public async Task<string> Post([FromBody] LocateCommand locateCommand)
        {
            var response = await _geoLocalizationService.CalculateLocation(locateCommand);
            return response;
        }
    }
}
