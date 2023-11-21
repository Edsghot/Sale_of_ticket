use SaleTicket
go
insert into Administrator values('aaae1119-448d-4825-a262-cc2100741ef9', 'Jheyson Jhair', 'Arone Angeles', '201056', '201056@unamba.edu.pe', '@jhaircito2003', '983805438', '75627242')
--insert into Administrator values('aaae1119-448d-4825-a262-cc2100741ef8', 'Ed Nativido', 'Soto Huamanhorcco', '201068', '201068@unamba.edu.pe', '@nativido2003', '945589632', '73639719')
go


insert into Period values('c4dcbaf6-63b9-4d95-bc33-9d428e0a5113', 20/11/2023, 01/12/2023, '2023-2')
insert into Period values('c4dcbaf6-63b9-4d95-bc33-9d428e0a5114', 04/12/2023, 15/12/2023, '2023-2')
go


insert into Opening values('3c16f152-cf20-4937-bd3a-87d7408c4fcd', 'c4dcbaf6-63b9-4d95-bc33-9d428e0a5113', 20, 100, 1)
insert into Opening values('7095c3e6-bd58-4a54-8f27-20327220408c', 'c4dcbaf6-63b9-4d95-bc33-9d428e0a5114', 20, 100, 1)
go


insert into AdministratorOpening values('3477edd7-306e-49e6-ad37-6ebccf055e17', 'aaae1119-448d-4825-a262-cc2100741ef9', '3c16f152-cf20-4937-bd3a-87d7408c4fcd')
insert into AdministratorOpening values('e8a6622b-5419-401b-9705-656d661575bb', 'aaae1119-448d-4825-a262-cc2100741ef9', '7095c3e6-bd58-4a54-8f27-20327220408c')
go


insert into Product values('4800cdd5-3561-46c4-883c-0ac986268a6e', 'Almuerzo', 10)
insert into Product values('4800cdd5-3561-46c4-883c-0ac986268a6a', 'Desayuno', 2)
go


insert into Student values('3ed228fa-4780-4d08-a82a-153acd1399e3', '', '46851555', 'Santiago', 'Pocco Oquendo', 1, 'UNAMBA', 'Ingeniería', 1, '989145236', 'Jr. Chalhuanca N°100', 'M', 1, '@Oquendo091', '091163@unamba.edu.pe', '091163')
insert into Student values('3ed228fa-4780-4d08-a82a-153acd1399e4', '', '70930383', 'Emerson', 'Ñahuinlla Velasquez', 0, 'UNAMBA', 'Ingeniería', 0, '914256333', 'Jr. Apurímac N°700', 'M', 0, '@Ñahuinlla709', '101131@unamba.edu.pe', '101131')
go

insert into SaleDetail values('cbde7001-a799-4651-8b64-b14e6a1e1c22', '4800cdd5-3561-46c4-883c-0ac986268a6e', 20/11/2023)
insert into SaleDetail values('7c049131-473e-4035-b221-cd8ef7e1a48f', '4800cdd5-3561-46c4-883c-0ac986268a6a', 20/11/2023)
go


insert into Sale values('a0e5c598-91c9-47a1-b3d0-5de69c9741b6', '3ed228fa-4780-4d08-a82a-153acd1399e3', 'c4dcbaf6-63b9-4d95-bc33-9d428e0a5114', 04/12/2023, 'https://mitokenonline.com/wp-content/uploads/2023/06/comprobante-yape.png', 1, 10)
insert into Sale values('1445af81-b3ea-4090-9294-74d9e41edc5f', '3ed228fa-4780-4d08-a82a-153acd1399e4', 'c4dcbaf6-63b9-4d95-bc33-9d428e0a5113', 01/12/2023, 'https://diarioviral.pe/ckfinder/userfiles/files/WhatsApp%20Image%202023-07-01%20at%204_46_00%20PM(1).jpeg', 1, 2)
go

select * from Sale where idStudent = '3ed228fa-4780-4d08-a82a-153acd1399e4'