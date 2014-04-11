-- Set Associations


alter table Locations
add constraint Locations_ClientId_FK FOREIGN KEY ( ClientId ) REFERENCES Clients(ClientId)

alter table ClientCardBalances
add constraint ClientCardBalances_ClientId_FK FOREIGN KEY ( ClientId ) REFERENCES Clients(ClientId)

alter table ClientCardBalances
add constraint ClientCardBalances_CardId_FK FOREIGN KEY ( CardId ) REFERENCES Cards(CardId)

alter table Cards
add constraint Cards_LoyaltyCardHolderId_FK FOREIGN KEY ( LoyaltyCardHolderId ) REFERENCES LoyaltyCardHolders(LoyaltyCardHolderId)

alter table Readers
add constraint Readers_LocationId_FK FOREIGN KEY ( LocationId ) REFERENCES Locations(LocationId)

alter table Transactions
add constraint Transactions_LocationId_FK FOREIGN KEY ( LocationId ) REFERENCES Locations(LocationId)

alter table Transactions
add constraint Transactions_ClientId_FK FOREIGN KEY ( ClientId ) REFERENCES Clients(ClientId)

alter table Transactions
add constraint Transactions_CardId_FK FOREIGN KEY ( CardId ) REFERENCES Cards(CardId)

alter table Transactions
add constraint Transactions_ReaderId_FK FOREIGN KEY ( ReaderId ) REFERENCES Readers(ReaderId)

alter table Transactions
add constraint Transactions_TransactionTypeId_FK FOREIGN KEY ( TransactionTypeId ) REFERENCES TransactionTypes(TransactionTypeId)
