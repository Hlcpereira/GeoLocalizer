/**
 * Copyright 2022 - Henrique Pereira/Hlcpereira
 *
 * SPDX-License-Identifier: Apache-2.0
 */

using System;
using System.Globalization;
using System.Net;
using System.Threading.Tasks;
using System.Xml;
using Newtonsoft.Json;

using Hlcpereira.GeoLocalizer.CrossCutting.Configs;
using Hlcpereira.GeoLocalizer.Domain.AppServices.Commands;
using Hlcpereira.GeoLocalizer.Domain.AppServices.Contracts;
using Hlcpereira.GeoLocalizer.Domain.Entities;

namespace Hlcpereira.GeoLocalizer.Domain.AppServices
{
    public class GeoLocalizationService : IGeoLocalizationService
    {
        protected GoogleApiConfig _googleApiConfig;

        public GeoLocalizationService(GoogleApiConfig googleApiConfig)
        {
            _googleApiConfig = googleApiConfig;
        }

        public async Task<Address> GetLocation(LocateCommand command)
        {
            var addressShortName = string.Empty;
            var addressCountry = string.Empty;
            var addressAdministrativeAreaLevel1 = string.Empty;
            var addressAdministrativeAreaLevel2 = string.Empty;
            var addressAdministrativeAreaLevel3 = string.Empty;
            var addressColloquialArea = string.Empty;
            var addressLocality = string.Empty;
            var addressSublocality = string.Empty;
            var addressNeighborhood = string.Empty;
            var addressRoute = string.Empty;
            var addressStreetNumber = string.Empty;
            var addressPostalCode = string.Empty;

            XmlDocument doc = new XmlDocument();

            doc.Load(string.Format(CultureInfo.InvariantCulture, "https://maps.googleapis.com/maps/api/geocode/xml?address={0}&sensor=false", command.Latitude, command.Longitude) + "&key=" + _googleApiConfig.ApiKey);
            var element = doc.SelectSingleNode("//GeocodeResponse/status");
            if (element == null || element.InnerText == "ZERO_RESULTS")
            {
                return null;
            }

            XmlNodeList xnList = doc.SelectNodes("//GeocodeResponse/result/address_component");

            if (xnList == null) return null;

            foreach (XmlNode xn in xnList)
            {
                var longname = xn["long_name"].InnerText;
                var shortname = xn["short_name"].InnerText;
                var typename = xn["type"]?.InnerText;

                switch (typename)
                {
                    case "country":
                        addressCountry = longname;
                        addressShortName = shortname;
                        break;
                    case "locality":
                        addressLocality = longname;
                        break;
                    case "sublocality":
                        addressSublocality = longname;
                        break;
                    case "neighborhood":
                        addressNeighborhood = longname;
                        break;
                    case "colloquial_area":
                        addressColloquialArea = longname;
                        break;
                    case "administrative_area_level_1":
                        addressAdministrativeAreaLevel1 = shortname;
                        break;
                    case "administrative_area_level_2":
                        addressAdministrativeAreaLevel2 = longname;
                        break;
                    case "administrative_area_level_3":
                        addressAdministrativeAreaLevel3 = longname;
                        break;
                    case "route":
                        addressRoute = shortname;
                        break;
                    case "street_number":
                        addressStreetNumber = shortname;
                        break;
                    case "postal_code":
                        addressPostalCode = longname;
                        break;
                }
            }

            return new Address
            {
                Country = addressCountry,
                State = addressAdministrativeAreaLevel1,
                City = addressLocality,
                Loc = addressStreetNumber + " " + addressRoute + " " + addressSublocality,
                Zip = addressPostalCode,
            };
        }
    }
}
