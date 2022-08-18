using ModelsLayer;
using RepoLayer;

namespace BusinessLayer
{
    public class ersBusinessLayer
    {
        private readonly ersRepoLayer _repoLayer;

        public ersBusinessLayer()
        {
            this._repoLayer = new ersRepoLayer();
        }

        //string type put in the business layer instead of controler due to seperation of concerns
        //try to get as much logic as possible in the business layer
        public async Task<List<Ticket>> TicketsAsync(int type)
        {
            List<Ticket> list = await this._repoLayer.TicketsAsync(type); //The whole thing from ersRepoLayer is returned to this list
            return list;//Then the ersRepoLayer list now ersBusinessLayer list goes to ersController where it was called
        }
    }
}