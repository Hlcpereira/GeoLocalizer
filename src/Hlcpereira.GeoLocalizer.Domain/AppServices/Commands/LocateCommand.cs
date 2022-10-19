/**
 * Copyright 2022 - Henrique Pereira/Hlcpereira
 *
 * SPDX-License-Identifier: Apache-2.0
 */

namespace Hlcpereira.GeoLocalizer.Domain.AppServices.Commands
{
    public class LocateCommand
    {
        public string Latitude { get; set; }

        public string Longitude { get; set; }
    }
}