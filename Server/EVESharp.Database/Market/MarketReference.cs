﻿namespace EVESharp.Database.Market;

public enum MarketReference
{
    SkipLog                         = -1,
    Undefined                       = 0,
    PlayerTrading                   = 1,
    MarketTransaction               = 2,
    GMCashTransfer                  = 3,
    ATMWithdraw                     = 4,
    ATMDeposit                      = 5,
    BackwardCompatible              = 6,
    MissionReward                   = 7,
    CloneActivation                 = 8,
    Inheritance                     = 9,
    PlayerDonation                  = 10,
    CorporationPayment              = 11,
    DockingFee                      = 12,
    OfficeRentalFee                 = 13,
    FactorySlotRentalFee            = 14,
    RepairBill                      = 15,
    Bounty                          = 16,
    BountyPrize                     = 17,
    Insurance                       = 19,
    MissionExpiration               = 20,
    MissionCompletion               = 21,
    Shares                          = 22,
    CourierMissionEscrow            = 23,
    MissionCost                     = 24,
    AgentMiscellaneous              = 25,
    MiscellaneousPaymentToAgent     = 26,
    AgentLocationServices           = 27,
    AgentDonation                   = 28,
    AgentSecurityServices           = 29,
    AgentMissionCollateralPaid      = 30,
    AgentMissionCollateralRefunded  = 31,
    AgentMissionReward              = 33,
    AgentMissionTimeBonusReward     = 34,
    CSPA                            = 35,
    CSPAOfflineRefund               = 36,
    CorporationAccountWithdrawal    = 37,
    CorporationDividendPayment      = 38,
    CorporationRegistrationFee      = 39,
    CorporationLogoChangeCost       = 40,
    ReleaseOfImpoundedProperty      = 41,
    MarketEscrow                    = 42,
    MarketFinePaid                  = 44,
    Brokerfee                       = 46,
    AllianceRegistrationFee         = 48,
    WarFee                          = 49,
    AllianceMaintainanceFee         = 50,
    ContrabandFine                  = 51,
    CloneTransfer                   = 52,
    AccelerationGateFee             = 53,
    TransactionTax                  = 54,
    JumpCloneInstallationFee        = 55,
    Manufacturing                   = 56,
    ResearchingTechnology           = 57,
    ResearchingTimeProductivity     = 58,
    ResearchingMaterialProductivity = 59,
    Copying                         = 60,
    Duplicating                     = 61,
    ReverseEngineering              = 62,
    ContractAuctionBid              = 63,
    ContractAuctionBidRefund        = 64,
    ContractCollateral              = 65,
    ContractRewardRefund            = 66,
    ContractAuctionSold             = 67,
    ContractReward                  = 68,
    ContractCollateralRefund        = 69,
    ContractCollateralPayout        = 70,
    ContractPrice                   = 71,
    ContractBrokersFee              = 72,
    ContractSalesTax                = 73,
    ContractDeposit                 = 74,
    ContractDepositSalesTax         = 75,
    SecureEVETimeCodeExchange       = 76,
    ContractAuctionBidCorp          = 77,
    ContractCollateralCorp          = 78,
    ContractPriceCorp               = 79,
    ContractBrokersFeeCorp          = 80,
    ContractDepositCorp             = 81,
    ContractDepositRefund           = 82,
    ContractRewardAdded             = 83,
    ContractRewardAddedCorp         = 84,
    BountyPrizes                    = 85,
    CorporationAdvertisementFee     = 86,
    MedalCreation                   = 87,
    MedalIssuing                    = 88,
    AttributeRespecification        = 90,
    CombatSimulator                 = 91
}