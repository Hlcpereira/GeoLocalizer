/**
 * Copyright 2022 - Henrique Pereira/Hlcpereira
 *
 * SPDX-License-Identifier: Apache-2.0
 */

using System;
using System.Globalization;
using System.Net;
using System.Threading.Tasks;
using Newtonsoft.Json;

using Hlcpereira.GeoLocalizer.Domain.AppServices.Commands;
using Hlcpereira.GeoLocalizer.Domain.AppServices.Contracts;
using Hlcpereira.GeoLocalizer.Domain.Entities;

namespace Hlcpereira.GeoLocalizer.Domain.AppServices
{
    public class GeoLocalizationService : IGeoLocalizationService
    {
        public async Task<string> CalculateLocation(LocateCommand locateCommand)
        {
            IpInfo ipInfo = new IpInfo();
            try
            {
                string info = new WebClient().DownloadString("http://ipinfo.io/" + locateCommand.IpAddress);
                ipInfo = JsonConvert.DeserializeObject<IpInfo>(info);
                //RegionInfo myRI1 = new RegionInfo(ipInfo.Country);
                //ipInfo.Country = myRI1.EnglishName;
            }
            catch (Exception)
            {
                ipInfo.Region = null;
            }

            return ipInfo.Region;
        }
    }
}