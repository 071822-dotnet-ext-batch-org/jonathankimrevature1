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



        public async Task<bool> LoginAsync(string Username, string Password)
        {
            bool SuccessfullLogin = await this._repoLayer.LoginAsync(Username, Password);
            return SuccessfullLogin;
        }



        public async Task<bool> RegisterUserAsync(Guid EmployeeID, string FirstName, string LastName, string Username, string Password)
        {
            bool SuccessfullyRegistered = await this._repoLayer.RegisterUserAsync(EmployeeID, FirstName, LastName, Username, Password);
            return SuccessfullyRegistered;
        }



        public async Task<bool> SubmitTicketAsync(Guid TicketID, Guid fK_Employee, string Description, decimal Amount)
        {
            bool SuccessfullySubmited = await this._repoLayer.SubmitTicketAsync(TicketID, fK_Employee, Description, Amount);
            return SuccessfullySubmited;
        }



        public async Task<UpdatedTicketDTO> UpdateTicketAsync(ApprovalDTO approvalDTO)
        {
            if (await this._repoLayer.IsManangerAsync(approvalDTO.EmployeeId))
            {
                UpdatedTicketDTO approvedRequest = await this._repoLayer.UpdateTicketAsync(approvalDTO.TicketID, approvalDTO.Status);
                return approvedRequest;
            }
            else return null;
        }



        public async Task<List<Ticket>> GetAllTicketsAsync(int Status)
        {
            List<Ticket> list = await this._repoLayer.GetAllTicketsAsync(Status);
            return list;
        }



        public async Task<bool> DoesUsernameAlreadyExistAsync(string Username)
        {
            bool DoesExist = await this._repoLayer.DoesUsernameAlreadyExistAsync(Username);
            return DoesExist;
        }



        public async Task<bool> IsitAlreadyProcessedAsync(Guid TicketID)
        {
            bool IsItProcessed = await this._repoLayer.IsitAlreadyProcessedAsync(TicketID);
            return IsItProcessed;
        }
    }
}