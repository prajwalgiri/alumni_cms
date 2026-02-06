using Microsoft.EntityFrameworkCore;
using Alumni.Domain.Entities;

namespace Alumni.Infrastructure.Data;

public static class AlumniSeed
{
    public static void Seed(ModelBuilder modelBuilder)
    {
        var roleId = Guid.Parse("44444444-4444-4444-4444-444444444444"); // Alumni role

        modelBuilder.Entity<User>().HasData(
            new User("anuj.govindajoshi0@example.com", "$2a$11$92IXUNpkjO0rOQ5byMi.Ye4oKoEa3Ro9llC/.og/at2.uheWG/igi", "Anuj", "Govinda Joshi", roleId)
            {
                Id = Guid.Parse("262be63e-1085-4841-8f55-7d52f6f43e57"),
                CreatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc),
                UpdatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc)
            },
            new User("ajay.shrestha1@example.com", "$2a$11$92IXUNpkjO0rOQ5byMi.Ye4oKoEa3Ro9llC/.og/at2.uheWG/igi", "Ajay", "Shrestha", roleId)
            {
                Id = Guid.Parse("7df0d247-72b6-4a45-83ad-854f62885a3c"),
                CreatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc),
                UpdatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc)
            },
            new User("bharat.kharal2@example.com", "$2a$11$92IXUNpkjO0rOQ5byMi.Ye4oKoEa3Ro9llC/.og/at2.uheWG/igi", "Bharat", "Kharal", roleId)
            {
                Id = Guid.Parse("c269770f-e72b-469c-8202-cf562889338f"),
                CreatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc),
                UpdatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc)
            },
            new User("binaya.vaidya3@example.com", "$2a$11$92IXUNpkjO0rOQ5byMi.Ye4oKoEa3Ro9llC/.og/at2.uheWG/igi", "Binaya", "Vaidya", roleId)
            {
                Id = Guid.Parse("8c507611-ba56-47e5-944a-d72c0ff97f14"),
                CreatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc),
                UpdatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc)
            },
            new User("arun.ghimire4@example.com", "$2a$11$92IXUNpkjO0rOQ5byMi.Ye4oKoEa3Ro9llC/.og/at2.uheWG/igi", "Arun", "Ghimire", roleId)
            {
                Id = Guid.Parse("0fa9c369-f455-4639-a49d-c0a595093503"),
                CreatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc),
                UpdatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc)
            },
            new User("rikesh.shrestha5@example.com", "$2a$11$92IXUNpkjO0rOQ5byMi.Ye4oKoEa3Ro9llC/.og/at2.uheWG/igi", "Rikesh", "Shrestha", roleId)
            {
                Id = Guid.Parse("eabb525a-a90d-4421-b8b6-5c8e793d9868"),
                CreatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc),
                UpdatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc)
            },
            new User("trimir.maharjan6@example.com", "$2a$11$92IXUNpkjO0rOQ5byMi.Ye4oKoEa3Ro9llC/.og/at2.uheWG/igi", "Trimir", "Maharjan", roleId)
            {
                Id = Guid.Parse("adcdaf28-d599-436e-a78b-d0d286114e14"),
                CreatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc),
                UpdatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc)
            },
            new User("aashna.saud7@example.com", "$2a$11$92IXUNpkjO0rOQ5byMi.Ye4oKoEa3Ro9llC/.og/at2.uheWG/igi", "Aashna", "Saud", roleId)
            {
                Id = Guid.Parse("c0e39cd3-bb8a-477a-90ea-54a7fd912d68"),
                CreatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc),
                UpdatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc)
            },
            new User("situ.shrestha8@example.com", "$2a$11$92IXUNpkjO0rOQ5byMi.Ye4oKoEa3Ro9llC/.og/at2.uheWG/igi", "Situ", "Shrestha", roleId)
            {
                Id = Guid.Parse("9179496d-1613-40b0-bdcf-0795ed6456a6"),
                CreatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc),
                UpdatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc)
            },
            new User("sunita.rai9@example.com", "$2a$11$92IXUNpkjO0rOQ5byMi.Ye4oKoEa3Ro9llC/.og/at2.uheWG/igi", "Sunita", "Rai", roleId)
            {
                Id = Guid.Parse("d3c0a3f9-96c9-469b-b2e8-4e853f7f92e9"),
                CreatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc),
                UpdatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc)
            },
            new User("anita.agrawal10@example.com", "$2a$11$92IXUNpkjO0rOQ5byMi.Ye4oKoEa3Ro9llC/.og/at2.uheWG/igi", "Anita", "Agrawal", roleId)
            {
                Id = Guid.Parse("1bc2175e-8d66-405d-b382-2d2edb25539e"),
                CreatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc),
                UpdatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc)
            },
            new User("umanga.bhatta11@example.com", "$2a$11$92IXUNpkjO0rOQ5byMi.Ye4oKoEa3Ro9llC/.og/at2.uheWG/igi", "Umanga", "Bhatta", roleId)
            {
                Id = Guid.Parse("1061ef5b-6102-44fa-8240-6b544739e585"),
                CreatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc),
                UpdatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc)
            },
            new User("rojesh.pradhan12@example.com", "$2a$11$92IXUNpkjO0rOQ5byMi.Ye4oKoEa3Ro9llC/.og/at2.uheWG/igi", "Rojesh", "Pradhan", roleId)
            {
                Id = Guid.Parse("b153cfcd-5b55-473c-8aeb-bc40d779ffba"),
                CreatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc),
                UpdatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc)
            }
        );

        modelBuilder.Entity<Alumni.Domain.Entities.Alumni>().HasData(
            new Alumni.Domain.Entities.Alumni(Guid.Parse("262be63e-1085-4841-8f55-7d52f6f43e57"), 2012, "MBA", "Management", "Huawei Technologies Nepal Co. Pvt. Ltd.", "Finance Controller / Account CFO (Nepal Carrier Account and Enterprise Business Group)", null, null, null, null, null, "https://saim.edu.np/storage/uploads/alumni/260130cMuobOb7fU99qcjY1hd7ysVmjagS9Ou8ETWr1wfJ.jpg", true)
            {
                Id = Guid.Parse("6cd3db2d-4bb6-4693-999c-d3a02298271e"),
                CreatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc),
                UpdatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc)
            },
            new Alumni.Domain.Entities.Alumni(Guid.Parse("7df0d247-72b6-4a45-83ad-854f62885a3c"), 2009, "MM", "Management", "Coca Cola", "Director", null, null, null, null, null, "https://saim.edu.np/storage/uploads/alumni/230711TU3VafOtLh5aRPPnE7K7khxxsdYAW4f0TZ55rTmz.jpg", true)
            {
                Id = Guid.Parse("d889db9a-784d-40b5-8b9f-640431ad0970"),
                CreatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc),
                UpdatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc)
            },
            new Alumni.Domain.Entities.Alumni(Guid.Parse("c269770f-e72b-469c-8202-cf562889338f"), 2016, "MBA", "Management", "Lions Leading Travel and Tour Pvt LTD", "CEO", null, null, null, null, null, "https://saim.edu.np/storage/uploads/alumni/230726RVftrcSYYvDxNl5EOR9ZywIkL2gaSDu9iEbkBywD.jpg", true)
            {
                Id = Guid.Parse("53fbb707-3dc7-4723-ad48-957f58c35eaa"),
                CreatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc),
                UpdatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc)
            },
            new Alumni.Domain.Entities.Alumni(Guid.Parse("8c507611-ba56-47e5-944a-d72c0ff97f14"), 2008, "MM", "Management", "", "Certified Executive and Life Coach", null, null, null, null, null, "https://saim.edu.np/storage/uploads/alumni/230749AahWf0XDDBeTaY2GJXb7WHbsNHEnrcFuKQPOKQ7l.jpg", true)
            {
                Id = Guid.Parse("b91027c1-cccd-4963-b9cf-80c90962349e"),
                CreatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc),
                UpdatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc)
            },
            new Alumni.Domain.Entities.Alumni(Guid.Parse("0fa9c369-f455-4639-a49d-c0a595093503"), 2018, "MBA", "Management", "CleanMe Laundry Services Pvt.Ltd", "Founder", null, null, null, null, null, "https://saim.edu.np/storage/uploads/alumni/2307015CrcA60NoIF75HWklcOnQjlI4oGZEeoPyKZnMvD0.jpg", true)
            {
                Id = Guid.Parse("60031424-d223-4879-b28a-bedbc6145b3d"),
                CreatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc),
                UpdatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc)
            },
            new Alumni.Domain.Entities.Alumni(Guid.Parse("eabb525a-a90d-4421-b8b6-5c8e793d9868"), 2010, "MBA", "Management", "Siddhartha Capital Limited", "Head, Merchant Banking & Business Development", null, null, null, null, null, "https://saim.edu.np/storage/uploads/alumni/230708doIrG9ehcGUxX7l1eBGcm1k7AvNko3qd8GT3uJSy.jpg", true)
            {
                Id = Guid.Parse("b4b8ee97-6874-4089-946f-ef03e030c265"),
                CreatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc),
                UpdatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc)
            },
            new Alumni.Domain.Entities.Alumni(Guid.Parse("adcdaf28-d599-436e-a78b-d0d286114e14"), 2010, "MBA", "Management", "Alite Construction Pvt.Ltd", "Executive Manager", null, null, null, null, null, "https://saim.edu.np/storage/uploads/alumni/230744SuzF29NWTbjx7HBKPZGTYcnyfkbb6HIzfRBd5pw0.jpg", true)
            {
                Id = Guid.Parse("3db7aba6-7d56-49b6-aa0f-94bfa983dfeb"),
                CreatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc),
                UpdatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc)
            },
            new Alumni.Domain.Entities.Alumni(Guid.Parse("c0e39cd3-bb8a-477a-90ea-54a7fd912d68"), 2018, "MBA", "Management", "Technology Services Fusemachines", "Assistant Manager", null, null, null, null, null, "https://saim.edu.np/storage/uploads/alumni/230737KbmeeEeKIqDfSvKv9Sm3UTkGA8SqDDcINndQiIyj.jpg", true)
            {
                Id = Guid.Parse("a1eb8095-d5b8-49c4-89a2-95ef3539879c"),
                CreatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc),
                UpdatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc)
            },
            new Alumni.Domain.Entities.Alumni(Guid.Parse("9179496d-1613-40b0-bdcf-0795ed6456a6"), 2012, "MBA", "Management", "Meghauli Serai A Taj Safari, Unnati Cultural Village,", "Cluster Sales & Marketing Manager", null, null, null, null, null, "https://saim.edu.np/storage/uploads/alumni/2307443y7Oa8YaGyBJTCDSTtbfYh3woN3UoY3gcua3gBT8.jpg", true)
            {
                Id = Guid.Parse("b71da4ec-f0e0-41c6-a051-06ec2de3ec3a"),
                CreatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc),
                UpdatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc)
            },
            new Alumni.Domain.Entities.Alumni(Guid.Parse("d3c0a3f9-96c9-469b-b2e8-4e853f7f92e9"), 2017, "MBA", "Management", "Kantipur Management Pvt. Ltd", "Sr. HR Officer", null, null, null, null, null, "https://saim.edu.np/storage/uploads/alumni/230754Dzg5yB66hFc8H2EvdwnNlU5uHvbGSmYcwxQ0nZZp.jpg", true)
            {
                Id = Guid.Parse("4c8ff2c7-12b3-4221-a90e-6ef5e1f28de5"),
                CreatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc),
                UpdatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc)
            },
            new Alumni.Domain.Entities.Alumni(Guid.Parse("1bc2175e-8d66-405d-b382-2d2edb25539e"), 2011, "MBA", "Management", "Dr Lal Path Labs", "partner", null, null, null, null, null, "https://saim.edu.np/storage/uploads/alumni/230724m2q4sicJw9ukuqW13tUzbgZB1pdiRLiuMMeVvtT0.jpg", true)
            {
                Id = Guid.Parse("040c1671-8008-4373-a8fc-271e6890eaef"),
                CreatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc),
                UpdatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc)
            },
            new Alumni.Domain.Entities.Alumni(Guid.Parse("1061ef5b-6102-44fa-8240-6b544739e585"), 2023, "MBA", "Management", "", "", null, null, null, null, null, "https://saim.edu.np/storage/uploads/alumni/230824FC3p60guGsbQgzdHEf2KD5sMrikr61guyIb7MriU.jpg", true)
            {
                Id = Guid.Parse("2018318d-1806-4909-89a0-023157e66719"),
                CreatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc),
                UpdatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc)
            },
            new Alumni.Domain.Entities.Alumni(Guid.Parse("b153cfcd-5b55-473c-8aeb-bc40d779ffba"), 2012, "MBA", "Management", "", "", null, null, null, null, null, "https://saim.edu.np/storage/uploads/alumni/250546VKQkQDtndyp4ZS7FVAZJBTlyQmVQgVkv0hIqO1ij.jpg", true)
            {
                Id = Guid.Parse("3f2805ce-a319-43ee-89f6-ab4f9ce2400f"),
                CreatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc),
                UpdatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc)
            }
        );
    }
}
