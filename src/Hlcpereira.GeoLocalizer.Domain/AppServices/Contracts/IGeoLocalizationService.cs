/**
 * Copyright 2022 - Henrique Pereira/Hlcpereira
 *
 * SPDX-License-Identifier: Apache-2.0
 */

using System.Threading.Tasks;

using Hlcpereira.GeoLocalizer.Domain.AppServices.Commands;

namespace Hlcpereira.GeoLocalizer.Domain.AppServices.Contracts
{
    public interface IGeoLocalizationService
    {
        public Task<string> CalculateLocation(LocateCommand locateCommand);
    }
}