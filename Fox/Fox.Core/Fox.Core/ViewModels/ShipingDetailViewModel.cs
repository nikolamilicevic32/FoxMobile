using Fox.Common.Models;
using Fox.MailServices;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using System.Threading.Tasks;

namespace Fox.Core.ViewModels
{
    public class ShipingDetailViewModel : MvxViewModel
    {
        private readonly IMailService _mailService;
        private PurchaseModel _purchaserModel;

        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public PurchaseModel PurchaserModel
        {
            get
            {
                return _purchaserModel;
            }
            set
            {
                _purchaserModel = value;
                RaisePropertyChanged();
            }
        }
        public ShipingDetailViewModel(IMailService mailService)
        {
            _mailService = mailService;
        }

        public override async Task Initialize()
        {
            await base.Initialize();
        }
        public async Task SendMailAction()
        {
            var purchaseModel = new PurchaseModel()
            {
                Address = Address,
                City = City,
                Name = Name,
                Phone = Phone,
                Email = Email
            };

            await _mailService.SendMail(purchaseModel);
        }
        public IMvxCommand FinalizePurchase
        {
            get
            {
                return new MvxCommand(async () => await SendMailAction() );
            }
        }

    }
}


