namespace SE_TeamZephyr.Migrations.Identity
{
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class IdentityConf : DbMigrationsConfiguration<IdentityDBContext>
    {
        public IdentityConf()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"Migrations\Identity";
        }

        protected override void Seed(IdentityDBContext context)
        {
            context.Users.AddOrUpdate(
            //With Vehicles (Drivers)
            new ApplicationUser
            {
                FirstName = "Connor",
                LastName = "Miller",
                Id = "0ac86f0b-e12e-4b61-9eec-ce3f3074c65f",
                Email = "connor@miller.com",
                EmailConfirmed = false,
                PhoneNumberConfirmed = false,
                TwoFactorEnabled = false,
                LockoutEnabled = true,
                PasswordHash = "ADJXEDevNzy8khqOMNSzbto7ra6LZnHuRhpNcycYgGNfmLwCzSFh50EQY40tbIXHww==",
                SecurityStamp = "f5ee4827-2851-4389-988a-744270a99013",
                UserName = "connor@miller.com",
                AccessFailedCount = 0
            },
            new ApplicationUser
            {
                FirstName = "Dervla",
                LastName = "Cullen",
                Id = "a44d3e2f-4cd3-48e5-bfff-6f9ff27e5e19",
                Email = "dervla@cullen.com",
                EmailConfirmed = false,
                PhoneNumberConfirmed = false,
                TwoFactorEnabled = false,
                LockoutEnabled = true,
                PasswordHash = "AHdxwGwpswh67nwvkNJCFi81UYKMY7ugZc9+I/bd3+VkID6LNtQFTRu2GLv3VQ4eHw==",
                SecurityStamp = "6edaf8b4-ae78-45bb-9e61-1740713f21c9",
                UserName = "dervla@cullen.com",
                AccessFailedCount = 0
            },
            new ApplicationUser
            {
                FirstName = "Ashlene",
                LastName = "Curran",
                Id = "2c09e341-f5f2-4362-8de7-f2f36f818c96",
                Email = "ashlene@curran.com",
                EmailConfirmed = false,
                PhoneNumberConfirmed = false,
                TwoFactorEnabled = false,
                LockoutEnabled = true,
                PasswordHash = "AKumBSIRP7NswZx+r9415wpVJPIzs0lbRFD7eewBGZg/oHJgILrBkf8cWXTEJxYiPA==",
                SecurityStamp = "191fe7d5-cc3c-4698-bba5-0da28d95414e",
                UserName = "ashlene@curran.com",
                AccessFailedCount = 0
            },
            new ApplicationUser
            {
                FirstName = "Jacob",
                LastName = "White",
                Id = "678fcef4-4bc0-4870-901d-461f9886ae57",
                Email = "jacob@white.com",
                EmailConfirmed = false,
                PhoneNumberConfirmed = false,
                TwoFactorEnabled = false,
                LockoutEnabled = true,
                PasswordHash = "AD0AeFY0DLOCwmpQnHI2PY0tUjZD0XsuS/J9nsRG41ItTY76eNXZ+Cc3AlXtNqxvig==",
                SecurityStamp = "b22875f5-bfa0-4539-b84f-62e8f6542576",
                UserName = "jacob@white.com",
                AccessFailedCount = 0
            },
            new ApplicationUser
            {
                FirstName = "Maeve",
                LastName = "Callaghan",
                Id = "6b5525fb-0f27-46a1-995d-1a81547363c7",
                Email = "maeve@callaghan.com",
                EmailConfirmed = false,
                PhoneNumberConfirmed = false,
                TwoFactorEnabled = false,
                LockoutEnabled = true,
                PasswordHash = "AJqeZaUsc7u5QyjZ5J8uwx6/y9nksZBUjjA+sk/P4h50roq70OPSxa5iZgLltXgOlw==",
                SecurityStamp = "f867baef-2362-45b2-b67b-21c680d916e8",
                UserName = "maeve@callaghan.com",
                AccessFailedCount = 0
            },
            new ApplicationUser
            {
                FirstName = "Brendan",
                LastName = "Campbell",
                Id = "83d2aef3-cd17-44b0-bfe4-651bb9957845",
                Email = "brendan@campbell.com",
                EmailConfirmed = false,
                PhoneNumberConfirmed = false,
                TwoFactorEnabled = false,
                LockoutEnabled = true,
                PasswordHash = "ACJwRL6uTO0+nRGMRxFYarEc8E8LHYHycElTwHAR64tz0VH2LE5DLlftn1qvDQecPw==",
                SecurityStamp = "df876dc1-670f-4ba7-8d0c-726ee866db8b",
                UserName = "brendan@campbell.com",
                AccessFailedCount = 0
            },

            //Without Vehicles (Passengers)
            new ApplicationUser
            {
                FirstName = "Rory",
                LastName = "O'Flaherty",
                Id = "0e327b31-bd41-45cb-afcb-b2ac3d8248ee",
                Email = "rory@oflaherty.com",
                EmailConfirmed = false,
                PhoneNumberConfirmed = false,
                TwoFactorEnabled = false,
                LockoutEnabled = true,
                PasswordHash = "AImHqEe/ifM0G49S2bYSxqPTwGE9bGlNlxKi+fqnnatJY8OsPjvo035x4g4yy46CyA==",
                SecurityStamp = "8b06e148-fb94-432c-b594-41d799c5378b",
                UserName = "rory@oflaherty.com",
                AccessFailedCount = 0
            },
            new ApplicationUser
            {
                FirstName = "Dominic",
                LastName = "Hill",
                Id = "86b99f41-e3ed-4803-9d34-55fd9bdae955",
                Email = "dominic@hill.com",
                EmailConfirmed = false,
                PhoneNumberConfirmed = false,
                TwoFactorEnabled = false,
                LockoutEnabled = true,
                PasswordHash = "AE8elqo19QzM1ZZ4Bq6MHiT95lxgqoWtd6anzBm7T5YBjWoCFFq+K3wAPb+22EYyiQ==",
                SecurityStamp = "58b3d1e6-9d4e-47a3-9d9e-5f157b7c816a",
                UserName = "dominic@hill.com",
                AccessFailedCount = 0
            },
            new ApplicationUser
            {
                FirstName = "Enda",
                LastName = "McShane",
                Id = "8ba117ba-4d35-4e3d-9a60-724623ab4937",
                Email = "enda@mcshane.com",
                EmailConfirmed = false,
                PhoneNumberConfirmed = false,
                TwoFactorEnabled = false,
                LockoutEnabled = true,
                PasswordHash = "AK5K4EKuzlidvana5dJw0BUm0ivfCkBFy0V3jA+E3j8BK82dxYiBWEH+sUeLRmWHwg==",
                SecurityStamp = "1bb9175d-e627-4f93-aefc-b69c948cbef5",
                UserName = "enda@mcshane.com",
                AccessFailedCount = 0
            },
            new ApplicationUser
            {
                FirstName = "Oscar",
                LastName = "Bennett",
                Id = "67150777-0c8a-43c9-b1f1-c57f7569d166",
                Email = "oscar@bennett.com",
                EmailConfirmed = false,
                PhoneNumberConfirmed = false,
                TwoFactorEnabled = false,
                LockoutEnabled = true,
                PasswordHash = "AB+Mlaz+nv6RdCV7S5XKLIfzz+kx754jk98wlmYZwTEJDsBdmIqqToXOVDB6M0mWdA==",
                SecurityStamp = "11d7235e-27ab-47ba-bacd-4794d483f25b",
                UserName = "oscar@bennett.com",
                AccessFailedCount = 0
            },
            new ApplicationUser
            {
                FirstName = "Scarlett",
                LastName = "Wright",
                Id = "b4d20000-980d-4548-8d0a-b0eb0f16fcc1",
                Email = "scarlett@wright.com",
                EmailConfirmed = false,
                PhoneNumberConfirmed = false,
                TwoFactorEnabled = false,
                LockoutEnabled = true,
                PasswordHash = "AAjJ8/elbeFGqJf8zBzAQW5Mln1KXRvv5087Jb58pQ924SZWvZlvYiDLJ2hJ2X0zkg==",
                SecurityStamp = "543d10c1-6dfa-4386-97d4-05ac12b13b43",
                UserName = "scarlett@wright.com",
                AccessFailedCount = 0
            },
            new ApplicationUser
            {
                FirstName = "Donna",
                LastName = "Morgan",
                Id = "b8fb7d2b-fe29-499c-a632-0a917eb8728e",
                Email = "donna@morgan.com",
                EmailConfirmed = false,
                PhoneNumberConfirmed = false,
                TwoFactorEnabled = false,
                LockoutEnabled = true,
                PasswordHash = "AFyvNhiDTfjtX2APt4rPJQCTdk4KljAs/Tq7pwUTtNBpmFGKYRoYwWBryGikT3My9A==",
                SecurityStamp = "985378f5-aa7c-4fac-bf18-7554ee6eb337",
                UserName = "donna@morgan.com",
                AccessFailedCount = 0
            },
            new ApplicationUser
            {
                FirstName = "James",
                LastName = "Kelly",
                Id = "bec65c7c-71eb-4760-ab30-1826c0f9c8f6",
                Email = "james@kelly.com",
                EmailConfirmed = false,
                PhoneNumberConfirmed = false,
                TwoFactorEnabled = false,
                LockoutEnabled = true,
                PasswordHash = "AC17TZu28lgfdD8ufZg/5tqSzzWtQbwXBpqVqqQaLv4DF+nmX37hGWlc4p1vqtUZ2Q==",
                SecurityStamp = "5ee347d0-c7f5-4a84-8f90-920262e1971b",
                UserName = "james@kelly.com",
                AccessFailedCount = 0
            },
            new ApplicationUser
            {
                FirstName = "Joan",
                LastName = "Clark",
                Id = "cb5edef2-6ede-4e42-aa7a-7462672cfb1d",
                Email = "joan@clark.com",
                EmailConfirmed = false,
                PhoneNumberConfirmed = false,
                TwoFactorEnabled = false,
                LockoutEnabled = true,
                PasswordHash = "AAD/Bg0HMoB0XnQ839mIxKsUjQsNS+zGykOyIIFxwYGbm4KPBVFckXpeZ9rjVYBoYw==",
                SecurityStamp = "8185d27a-cae8-46df-9f2b-e0444f6e8d2b",
                UserName = "joan@clark.com",
                AccessFailedCount = 0
            },
            new ApplicationUser
            {
                FirstName = "Emer",
                LastName = "Flanagan",
                Id = "cd55e5c6-e346-4656-ad3c-ab8936639471",
                Email = "emer@flanagan.com",
                EmailConfirmed = false,
                PhoneNumberConfirmed = false,
                TwoFactorEnabled = false,
                LockoutEnabled = true,
                PasswordHash = "AOFUtPjTveTtZTteEClEk+mGwAHwpXQc2w+scf0sEN12uUxpNQeVjsK5B5iq/6OVZA==",
                SecurityStamp = "fb7ce42d-67d9-4264-af5b-926914a25b40",
                UserName = "emer@flanagan.com",
                AccessFailedCount = 0
            },
            new ApplicationUser
            {
                FirstName = "Nathan",
                LastName = "Smith",
                Id = "fe1a325f-9182-4a08-a9e7-8aa8741176c9",
                Email = "nathan@smith.com",
                EmailConfirmed = false,
                PhoneNumberConfirmed = false,
                TwoFactorEnabled = false,
                LockoutEnabled = true,
                PasswordHash = "AIu4/bKdKCdXJXDmlZH8XzDO9j49+NRkEP29FKmWy5cYB1z1Lf3tSeWHJRkMF3JVCw==",
                SecurityStamp = "7f21f70c-db53-4d47-9758-247846294adb",
                UserName = "nathan@smith.com",
                AccessFailedCount = 0
            }
            );
            context.SaveChanges();
        }
    }
}
