using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AssetGuard.Core.Entities;
using AssetGuard.Core.Interfaces;
using AssetGuard.Services.Interfaces;

namespace AssetGuard.Services.Services
{
    public class DigitalTwinService : IDigitalTwinService
    {
        private readonly IUnitOfWork _unitOfWork;
        public DigitalTwinService(IUnitOfWork unitOfWork) { _unitOfWork = unitOfWork; }

        public async Task<DigitalTwin> CreateTwinAsync(DigitalTwin twin)
        {
            await _unitOfWork.Repository<DigitalTwin>().AddAsync(twin);
            await _unitOfWork.CompleteAsync();
            return twin;
        }

        public async Task<DigitalTwin> SyncMainAssetAsync(int twinId)
        {
            var twin = await _unitOfWork.Repository<DigitalTwin>().GetByIdAsync(twinId);
            if (twin != null) { twin.LastSyncedAt = DateTime.UtcNow; await _unitOfWork.CompleteAsync(); }
            return twin;
        }

        public async Task<SimulationScenario> RunSimulationAsync(int twinId, string scenarioParams)
        {
            var sim = new SimulationScenario { AssetId = twinId, Parameters = scenarioParams, RunAt = DateTime.UtcNow };
            await _unitOfWork.Repository<SimulationScenario>().AddAsync(sim);
            await _unitOfWork.CompleteAsync();
            return sim;
        }

        public async Task<IEnumerable<SimulationScenario>> GetSimulationHistoryAsync(int twinId)
        {
            var all = await _unitOfWork.Repository<SimulationScenario>().GetAllAsync();
            return all.Where(s => s.AssetId == twinId);
        }

        public async Task<string> GetCadModelUrlAsync(int assetId) => "http://models.com/123";
    }
}
