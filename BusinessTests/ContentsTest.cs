using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Autofac.Builder;
using Business.Abstract;
using Business.DependencyResolvers.AutoFac;
using Entities.Concrete;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace BusinessTests
{
    class ContentsTests
    {
        private IContainer _container;
        private IContentService _contentService;


        public ContentsTests()
        {
            var containerBuilder = new ContainerBuilder();

            // register module to test
            containerBuilder.RegisterModule<AutofacBusinessModule>();

            // don't start startable components - 
            // we don't need them to start for the unit test
            _container = containerBuilder.Build(
                ContainerBuildOptions.IgnoreStartableComponents);
            _contentService = _container.Resolve<IContentService>();
        }
        [SetUp]
        public void SetUp()
        {

        }

        [Test]
        public void ContentTest()
        {
            #region MyRegion




            var data = new[] {
    new {
        Title = "rutrum urna, nec",
        Description = "dignissim lacus. Aliquam rutrum lorem",
        UserId = 1,
        Photos = "egestas rhoncus. Proin nisl"
    },
    new {
        Title = "tincidunt adipiscing. Mauris",
        Description = "interdum. Curabitur dictum. Phasellus in felis. Nulla tempor",
        UserId = 2,
        Photos = "amet nulla. Donec non"
    },
    new {
        Title = "malesuada id, erat. Etiam vestibulum massa rutrum magna. Cras",
        Description = "velit. Cras lorem lorem, luctus ut, pellentesque eget, dictum",
        UserId = 3,
        Photos = "Aliquam erat volutpat. Nulla facilisis. Suspendisse commodo tincidunt nibh."
    },
    new {
        Title = "accumsan convallis, ante lectus convallis est, vitae",
        Description = "lobortis quam a felis ullamcorper viverra. Maecenas iaculis aliquet diam.",
        UserId = 4,
        Photos = "mollis non, cursus non, egestas a, dui."
    },
    new {
        Title = "Sed molestie. Sed",
        Description = "ac",
        UserId = 5,
        Photos = "non, cursus"
    },
    new {
        Title = "rutrum urna, nec luctus felis purus ac tellus.",
        Description = "mollis nec, cursus a, enim. Suspendisse aliquet, sem ut",
        UserId = 6,
        Photos = "diam luctus lobortis. Class aptent taciti sociosqu"
    },
    new {
        Title = "Cras",
        Description = "vel est tempor bibendum.",
        UserId = 7,
        Photos = "mauris, aliquam eu, accumsan sed,"
    },
    new {
        Title = "sociis natoque penatibus et magnis dis parturient montes, nascetur",
        Description = "purus gravida sagittis. Duis",
        UserId = 8,
        Photos = "risus. Nulla eget metus eu erat"
    },
    new {
        Title = "Curabitur vel lectus. Cum sociis natoque penatibus",
        Description = "tempor lorem, eget",
        UserId = 9,
        Photos = "sagittis felis. Donec tempor, est ac mattis semper,"
    },
    new {
        Title = "ac facilisis facilisis, magna tellus faucibus leo,",
        Description = "pretium aliquet, metus urna",
        UserId = 10,
        Photos = "purus gravida sagittis. Duis gravida. Praesent eu"
    },
    new {
        Title = "Donec tincidunt. Donec vitae erat vel pede blandit congue.",
        Description = "senectus et netus et malesuada fames ac turpis egestas.",
        UserId = 11,
        Photos = "lobortis,"
    },
    new {
        Title = "Nullam lobortis quam a felis ullamcorper viverra. Maecenas",
        Description = "Cras dolor dolor, tempus non, lacinia at, iaculis quis,",
        UserId = 12,
        Photos = "non, luctus sit amet, faucibus"
    },
    new {
        Title = "rhoncus. Proin nisl sem, consequat",
        Description = "tempus risus. Donec egestas. Duis ac arcu. Nunc",
        UserId = 13,
        Photos = "est"
    },
    new {
        Title = "sed pede.",
        Description = "Phasellus at augue id ante dictum cursus. Nunc",
        UserId = 14,
        Photos = "nunc. In at pede."
    },
    new {
        Title = "et, euismod et, commodo",
        Description = "dolor egestas rhoncus. Proin nisl sem, consequat nec, mollis",
        UserId = 15,
        Photos = "odio semper"
    },
    new {
        Title = "fringilla euismod enim. Etiam gravida molestie arcu. Sed",
        Description = "libero lacus, varius et, euismod et, commodo at, libero. Morbi",
        UserId = 16,
        Photos = "mus. Aenean eget magna. Suspendisse tristique neque"
    },
    new {
        Title = "dis parturient",
        Description = "consectetuer rhoncus.",
        UserId = 17,
        Photos = "neque. Nullam ut nisi a odio semper"
    },
    new {
        Title = "et, rutrum eu, ultrices sit amet, risus. Donec nibh enim,",
        Description = "parturient montes, nascetur ridiculus",
        UserId = 18,
        Photos = "est mauris, rhoncus id, mollis nec,"
    },
    new {
        Title = "ornare",
        Description = "porttitor interdum. Sed auctor odio a purus. Duis",
        UserId = 19,
        Photos = "risus. In mi pede, nonummy ut,"
    },
    new {
        Title = "nulla magna, malesuada vel, convallis in, cursus et, eros. Proin",
        Description = "sit amet orci. Ut sagittis lobortis mauris. Suspendisse aliquet molestie",
        UserId = 20,
        Photos = "sapien, gravida non,"
    },
    new {
        Title = "eu nibh vulputate mauris sagittis placerat. Cras",
        Description = "fringilla cursus purus. Nullam scelerisque neque sed",
        UserId = 21,
        Photos = "in sodales elit erat vitae risus. Duis a mi fringilla"
    },
    new {
        Title = "Cras lorem lorem, luctus ut, pellentesque eget,",
        Description = "arcu eu odio tristique pharetra. Quisque ac",
        UserId = 22,
        Photos = "lorem, luctus ut,"
    },
    new {
        Title = "malesuada augue ut",
        Description = "ligula. Aliquam erat volutpat. Nulla dignissim. Maecenas ornare",
        UserId = 23,
        Photos = "velit eu sem. Pellentesque ut ipsum"
    },
    new {
        Title = "placerat, orci lacus vestibulum lorem, sit",
        Description = "pede ac urna. Ut tincidunt vehicula risus.",
        UserId = 24,
        Photos = "tellus. Aenean egestas"
    },
    new {
        Title = "tempus,",
        Description = "velit. Cras lorem lorem, luctus ut, pellentesque eget, dictum",
        UserId = 25,
        Photos = "fermentum arcu. Vestibulum ante ipsum primis"
    },
    new {
        Title = "nascetur ridiculus mus. Donec dignissim magna",
        Description = "laoreet ipsum. Curabitur",
        UserId = 26,
        Photos = "id"
    },
    new {
        Title = "amet lorem semper auctor. Mauris vel turpis. Aliquam adipiscing lobortis",
        Description = "ut mi. Duis risus odio, auctor vitae, aliquet nec,",
        UserId = 27,
        Photos = "adipiscing"
    },
    new {
        Title = "feugiat tellus lorem eu",
        Description = "Phasellus fermentum convallis ligula.",
        UserId = 28,
        Photos = "tempus scelerisque, lorem ipsum sodales purus,"
    },
    new {
        Title = "iaculis aliquet diam. Sed diam",
        Description = "vulputate mauris sagittis placerat. Cras dictum",
        UserId = 29,
        Photos = "primis in faucibus"
    },
    new {
        Title = "nisi dictum augue malesuada",
        Description = "laoreet posuere, enim nisl elementum purus, accumsan interdum libero dui",
        UserId = 30,
        Photos = "auctor odio a purus."
    },
    new {
        Title = "sed turpis nec mauris blandit mattis. Cras eget nisi",
        Description = "cubilia Curae Donec tincidunt. Donec",
        UserId = 31,
        Photos = "dui. Cras pellentesque. Sed"
    },
    new {
        Title = "ipsum. Curabitur consequat, lectus sit amet luctus",
        Description = "hendrerit a, arcu. Sed et",
        UserId = 32,
        Photos = "Curabitur vel"
    },
    new {
        Title = "ante. Vivamus non lorem vitae odio sagittis semper. Nam",
        Description = "mauris erat eget ipsum. Suspendisse sagittis. Nullam",
        UserId = 33,
        Photos = "sapien. Nunc pulvinar"
    },
    new {
        Title = "non dui",
        Description = "commodo hendrerit. Donec",
        UserId = 34,
        Photos = "volutpat ornare, facilisis eget,"
    },
    new {
        Title = "porttitor interdum. Sed auctor odio",
        Description = "nascetur ridiculus mus. Donec dignissim magna",
        UserId = 35,
        Photos = "Nunc"
    },
    new {
        Title = "vel sapien imperdiet ornare.",
        Description = "pede nec ante blandit viverra. Donec tempus, lorem",
        UserId = 36,
        Photos = "Sed nulla ante, iaculis nec, eleifend non, dapibus rutrum, justo."
    },
    new {
        Title = "Nullam",
        Description = "dolor sit amet, consectetuer adipiscing",
        UserId = 37,
        Photos = "placerat, augue. Sed molestie. Sed id risus quis diam"
    },
    new {
        Title = "eu,",
        Description = "tincidunt. Donec vitae erat vel pede blandit congue. In",
        UserId = 38,
        Photos = "commodo auctor velit. Aliquam"
    },
    new {
        Title = "velit eu sem. Pellentesque ut ipsum ac mi",
        Description = "nulla.",
        UserId = 39,
        Photos = "convallis erat, eget tincidunt dui augue eu tellus."
    },
    new {
        Title = "odio. Etiam",
        Description = "vulputate, risus a ultricies adipiscing,",
        UserId = 40,
        Photos = "gravida non, sollicitudin a, malesuada id, erat. Etiam vestibulum"
    },
    new {
        Title = "mauris.",
        Description = "Duis risus odio, auctor vitae, aliquet nec,",
        UserId = 41,
        Photos = "risus."
    },
    new {
        Title = "semper. Nam tempor diam dictum sapien.",
        Description = "Fusce fermentum fermentum arcu. Vestibulum ante ipsum",
        UserId = 42,
        Photos = "ante ipsum primis in faucibus"
    },
    new {
        Title = "Sed nulla ante, iaculis",
        Description = "hendrerit. Donec porttitor tellus non magna. Nam ligula elit,",
        UserId = 43,
        Photos = "feugiat. Sed nec metus facilisis"
    },
    new {
        Title = "fringilla purus mauris a nunc.",
        Description = "eu, ligula. Aenean euismod mauris",
        UserId = 44,
        Photos = "elit erat vitae risus. Duis a mi fringilla"
    },
    new {
        Title = "urna. Ut tincidunt vehicula",
        Description = "purus. Nullam scelerisque neque sed sem",
        UserId = 45,
        Photos = "commodo tincidunt"
    },
    new {
        Title = "commodo hendrerit. Donec porttitor tellus",
        Description = "leo. Vivamus",
        UserId = 46,
        Photos = "at, iaculis"
    },
    new {
        Title = "elit elit fermentum risus, at",
        Description = "enim nec tempus",
        UserId = 47,
        Photos = "ut mi. Duis risus odio, auctor vitae, aliquet nec,"
    },
    new {
        Title = "tincidunt congue turpis. In condimentum. Donec at arcu. Vestibulum ante",
        Description = "ut dolor dapibus gravida. Aliquam tincidunt, nunc",
        UserId = 48,
        Photos = "libero lacus, varius et, euismod et, commodo at, libero."
    },
    new {
        Title = "pede. Cras vulputate",
        Description = "mus. Proin vel",
        UserId = 49,
        Photos = "mauris sit amet"
    },
    new {
        Title = "consectetuer adipiscing elit.",
        Description = "rutrum non, hendrerit id, ante. Nunc mauris",
        UserId = 50,
        Photos = "semper et, lacinia"
    },
    new {
        Title = "vel, faucibus id, libero. Donec consectetuer mauris id sapien.",
        Description = "ut aliquam iaculis, lacus",
        UserId = 51,
        Photos = "enim, sit"
    },
    new {
        Title = "sollicitudin",
        Description = "eu tellus eu augue porttitor interdum. Sed auctor",
        UserId = 52,
        Photos = "nibh lacinia orci, consectetuer"
    },
    new {
        Title = "Ut tincidunt orci quis",
        Description = "enim. Etiam imperdiet dictum magna. Ut tincidunt orci quis",
        UserId = 53,
        Photos = "hendrerit. Donec porttitor tellus"
    },
    new {
        Title = "mattis. Integer eu",
        Description = "mauris id sapien. Cras dolor dolor,",
        UserId = 54,
        Photos = "nec, imperdiet nec,"
    },
    new {
        Title = "Aliquam ornare, libero at auctor ullamcorper, nisl arcu",
        Description = "neque vitae",
        UserId = 55,
        Photos = "eget odio. Aliquam vulputate ullamcorper magna. Sed eu eros. Nam"
    },
    new {
        Title = "semper et, lacinia vitae, sodales at,",
        Description = "nunc. Quisque",
        UserId = 56,
        Photos = "nunc, ullamcorper eu, euismod ac, fermentum vel, mauris. Integer"
    },
    new {
        Title = "in, cursus et, eros. Proin ultrices. Duis volutpat",
        Description = "turpis egestas. Aliquam fringilla",
        UserId = 57,
        Photos = "urna et arcu"
    },
    new {
        Title = "purus, in molestie tortor nibh sit",
        Description = "nunc. In at pede. Cras",
        UserId = 58,
        Photos = "ipsum nunc id enim. Curabitur massa. Vestibulum accumsan neque"
    },
    new {
        Title = "cursus et, eros.",
        Description = "senectus et netus",
        UserId = 59,
        Photos = "non quam. Pellentesque habitant morbi tristique senectus"
    },
    new {
        Title = "In scelerisque scelerisque",
        Description = "nunc interdum feugiat.",
        UserId = 60,
        Photos = "magna. Ut tincidunt orci quis lectus. Nullam suscipit, est"
    },
    new {
        Title = "vel arcu eu odio tristique",
        Description = "justo. Praesent luctus. Curabitur",
        UserId = 61,
        Photos = "vulputate, risus a ultricies adipiscing,"
    },
    new {
        Title = "erat neque non quam.",
        Description = "feugiat placerat velit. Quisque varius. Nam porttitor scelerisque",
        UserId = 62,
        Photos = "vel, faucibus id,"
    },
    new {
        Title = "mauris blandit mattis. Cras eget nisi",
        Description = "ut lacus. Nulla tincidunt, neque vitae semper egestas,",
        UserId = 63,
        Photos = "Pellentesque ultricies dignissim lacus. Aliquam rutrum"
    },
    new {
        Title = "feugiat nec, diam. Duis mi enim, condimentum",
        Description = "eu enim.",
        UserId = 64,
        Photos = "congue, elit"
    },
    new {
        Title = "blandit congue.",
        Description = "iaculis nec, eleifend non, dapibus rutrum, justo. Praesent luctus.",
        UserId = 65,
        Photos = "libero. Proin mi. Aliquam gravida mauris ut"
    },
    new {
        Title = "Maecenas",
        Description = "lobortis, nisi nibh lacinia orci, consectetuer euismod est arcu",
        UserId = 66,
        Photos = "fringilla est. Mauris eu turpis. Nulla aliquet."
    },
    new {
        Title = "ac metus vitae velit egestas lacinia. Sed congue,",
        Description = "ligula. Aliquam erat volutpat. Nulla dignissim.",
        UserId = 67,
        Photos = "imperdiet ornare. In faucibus. Morbi vehicula. Pellentesque"
    },
    new {
        Title = "vel, mauris. Integer sem elit, pharetra ut, pharetra",
        Description = "diam at pretium aliquet,",
        UserId = 68,
        Photos = "euismod est arcu ac orci."
    },
    new {
        Title = "a mi fringilla mi lacinia mattis. Integer",
        Description = "dictum",
        UserId = 69,
        Photos = "Donec feugiat metus sit amet ante. Vivamus"
    },
    new {
        Title = "adipiscing fringilla, porttitor vulputate, posuere",
        Description = "sagittis lobortis mauris. Suspendisse aliquet",
        UserId = 70,
        Photos = "lectus. Nullam suscipit, est ac facilisis facilisis,"
    },
    new {
        Title = "pellentesque a,",
        Description = "ac orci. Ut semper",
        UserId = 71,
        Photos = "Phasellus vitae mauris"
    },
    new {
        Title = "eu, placerat eget, venenatis a, magna. Lorem ipsum dolor",
        Description = "neque tellus, imperdiet",
        UserId = 72,
        Photos = "scelerisque neque. Nullam nisl. Maecenas malesuada fringilla est. Mauris eu"
    },
    new {
        Title = "malesuada malesuada. Integer id magna et ipsum cursus vestibulum.",
        Description = "blandit viverra. Donec tempus, lorem fringilla ornare placerat, orci lacus",
        UserId = 73,
        Photos = "Nam consequat dolor vitae dolor. Donec fringilla. Donec feugiat metus"
    },
    new {
        Title = "Phasellus dapibus quam quis",
        Description = "vulputate, lacus. Cras interdum. Nunc sollicitudin commodo ipsum.",
        UserId = 74,
        Photos = "molestie in, tempus eu, ligula. Aenean euismod mauris eu"
    },
    new {
        Title = "ullamcorper. Duis cursus, diam at pretium aliquet, metus urna convallis",
        Description = "eu tellus. Phasellus",
        UserId = 75,
        Photos = "ligula consectetuer rhoncus. Nullam velit dui, semper et,"
    },
    new {
        Title = "a felis",
        Description = "enim commodo hendrerit. Donec porttitor tellus",
        UserId = 76,
        Photos = "augue malesuada malesuada. Integer id"
    },
    new {
        Title = "lacus vestibulum lorem, sit amet ultricies sem magna",
        Description = "sapien imperdiet ornare. In faucibus. Morbi vehicula. Pellentesque",
        UserId = 77,
        Photos = "metus urna convallis"
    },
    new {
        Title = "feugiat tellus lorem eu metus. In",
        Description = "dolor.",
        UserId = 78,
        Photos = "sem, vitae aliquam eros turpis non"
    },
    new {
        Title = "quis lectus. Nullam",
        Description = "arcu. Sed",
        UserId = 79,
        Photos = "tincidunt, nunc ac mattis ornare, lectus ante"
    },
    new {
        Title = "laoreet ipsum. Curabitur consequat, lectus",
        Description = "diam eu dolor egestas rhoncus. Proin nisl sem,",
        UserId = 80,
        Photos = "pellentesque, tellus sem mollis dui, in sodales"
    },
    new {
        Title = "egestas hendrerit neque.",
        Description = "ante, iaculis nec, eleifend non, dapibus rutrum,",
        UserId = 81,
        Photos = "lacinia orci, consectetuer euismod"
    },
    new {
        Title = "vestibulum lorem,",
        Description = "dui, nec",
        UserId = 82,
        Photos = "augue. Sed molestie."
    },
    new {
        Title = "sociis natoque penatibus",
        Description = "sem eget massa. Suspendisse eleifend. Cras sed",
        UserId = 83,
        Photos = "consectetuer rhoncus. Nullam velit dui,"
    },
    new {
        Title = "dictum magna. Ut tincidunt",
        Description = "dignissim. Maecenas ornare egestas ligula. Nullam feugiat placerat",
        UserId = 84,
        Photos = "eleifend nec, malesuada ut, sem. Nulla interdum. Curabitur"
    },
    new {
        Title = "quis urna. Nunc quis arcu vel",
        Description = "mauris eu elit.",
        UserId = 85,
        Photos = "a, scelerisque sed, sapien."
    },
    new {
        Title = "erat neque non quam.",
        Description = "a, aliquet vel, vulputate eu, odio. Phasellus at",
        UserId = 86,
        Photos = "semper tellus id nunc interdum"
    },
    new {
        Title = "metus. In lorem. Donec elementum, lorem ut aliquam",
        Description = "tincidunt vehicula",
        UserId = 87,
        Photos = "tortor. Nunc commodo auctor velit. Aliquam nisl. Nulla eu"
    },
    new {
        Title = "ante ipsum primis in faucibus orci luctus et ultrices",
        Description = "tempus scelerisque,",
        UserId = 88,
        Photos = "malesuada fames ac turpis egestas. Fusce"
    },
    new {
        Title = "rutrum. Fusce dolor",
        Description = "fames ac turpis egestas. Aliquam fringilla cursus purus. Nullam",
        UserId = 89,
        Photos = "nibh. Aliquam ornare,"
    },
    new {
        Title = "quis turpis vitae",
        Description = "Donec non justo. Proin non massa non ante",
        UserId = 90,
        Photos = "et ipsum cursus vestibulum. Mauris magna."
    },
    new {
        Title = "Curabitur vel lectus. Cum sociis natoque penatibus",
        Description = "magnis dis parturient montes, nascetur ridiculus",
        UserId = 91,
        Photos = "ligula. Aenean gravida"
    },
    new {
        Title = "tellus. Suspendisse sed dolor. Fusce mi lorem, vehicula et,",
        Description = "In tincidunt",
        UserId = 92,
        Photos = "ac facilisis facilisis, magna tellus faucibus leo, in lobortis tellus"
    },
    new {
        Title = "mi enim, condimentum eget, volutpat",
        Description = "pharetra, felis eget varius ultrices, mauris ipsum porta elit, a",
        UserId = 93,
        Photos = "posuere,"
    },
    new {
        Title = "a neque. Nullam ut nisi a odio semper cursus. Integer",
        Description = "nisi. Aenean",
        UserId = 94,
        Photos = "Integer vulputate, risus a ultricies adipiscing,"
    },
    new {
        Title = "dolor sit amet,",
        Description = "Sed molestie. Sed id risus quis diam luctus lobortis.",
        UserId = 95,
        Photos = "iaculis nec, eleifend non,"
    },
    new {
        Title = "Aliquam ultrices iaculis odio. Nam interdum enim non nisi. Aenean",
        Description = "elit fermentum risus, at",
        UserId = 96,
        Photos = "egestas. Sed pharetra, felis eget"
    },
    new {
        Title = "vitae mauris sit",
        Description = "dictum",
        UserId = 97,
        Photos = "dapibus id, blandit at,"
    },
    new {
        Title = "mauris. Morbi non",
        Description = "Morbi vehicula. Pellentesque",
        UserId = 98,
        Photos = "placerat. Cras dictum ultricies ligula."
    },
    new {
        Title = "elit erat vitae risus. Duis a mi fringilla mi",
        Description = "quis accumsan convallis, ante lectus convallis est, vitae sodales",
        UserId = 99,
        Photos = "Cras interdum. Nunc sollicitudin commodo ipsum. Suspendisse non leo. Vivamus"
    },
    new {
        Title = "quis turpis vitae purus gravida sagittis. Duis",
        Description = "venenatis vel, faucibus id, libero. Donec",
        UserId = 100,
        Photos = "sem, vitae aliquam eros turpis non enim. Mauris"
    }
};
            #endregion

            foreach (var content in data)
            {
                var c = new Content
                {
                    Description = content.Description,
                    UserId = content.UserId,
                    Photos = content.Photos,
                    Title = content.Title
                };
                _contentService.Add(c);
            }
        }
    }
}
