using System.Collections.Generic;
using System.Threading.Tasks;
using AssetGuard.Core.Entities;

namespace AssetGuard.Services.Interfaces
{
    public interface IDigitalTwinService
    {
        Task<DigitalTwin> CreateTwinAsync(DigitalTwin twin);
        Task<DigitalTwin> SyncMainAssetAsync(int twinId);
        Task<SimulationScenario> RunSimulationAsync(int twinId, string scenarioParams);
        Task<IEnumerable<SimulationScenario>> GetSimulationHistoryAsync(int twinId);
        Task<string> GetCadModelUrlAsync(int assetId);
    }
}
