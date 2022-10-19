/**
 * Copyright 2022 - Henrique Pereira/Hlcpereira
 *
 * SPDX-License-Identifier: Apache-2.0
 */

using System.Threading.Tasks;

using Hlcpereira.GeoLocalizer.Domain.AppServices.Commands;
using Hlcpereira.GeoLocalizer.Domain.Entities;

namespace Hlcpereira.GeoLocalizer.Domain.AppServices.Contracts
{
    public interface IGeoLocalizationService
    {
        public Task<Address> GetLocation(LocateCommand command);
    }
}