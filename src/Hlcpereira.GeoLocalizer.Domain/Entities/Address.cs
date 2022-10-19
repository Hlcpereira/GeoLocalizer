/**
* Copyright 2022 - Henrique Pereira/Hlcpereira
*
* SPDX-License-Identifier: Apache-2.0
*/

namespace Hlcpereira.GeoLocalizer.Domain.Entities
{
    public class Address
    {
        public string City { get; set; }

        public string State { get; set; }
    
        public string Country { get; set; }

        public string Loc { get; set; }

        public string Zip { get; set; }
    }
}
