using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APITestApp.SingleOutcodeServicesTests;

public class WhenTheSingleOutcodeServiceIsCalled_WithInvalidOutcode
{
    SingleOutcodeService _singleOutcodeService;

    [OneTimeSetUp]
    public async Task OneTimeSetUpAsync()
    {
        _singleOutcodeService = new SingleOutcodeService();
        await _singleOutcodeService.MakesRequestAsync("lmao");
    }

    [Test]
    public void StatusIsNot200_InJsonResponse()
    {
        Assert.That(_singleOutcodeService.ResponseContent["status"].ToString(), Is.Not.EqualTo("200"));
    }

    [Test]
    public void StatusIsNot200()
    {
        Assert.That(_singleOutcodeService.GetStatusCode(), Is.Not.EqualTo(200));
    }
    [Test]
    public void ObjectStatusIsNot200()
    {
        Assert.That(_singleOutcodeService.ResponseObject.status, Is.Not.EqualTo(200));
    }
    [Test]
    public void StatusInResponseHeader_SameAsResponseBody()
    {
        var bodyResponseStatusCode = _singleOutcodeService.ResponseContent["status"].ToString();
        var bodyResponseStatusCodeInt = int.Parse(bodyResponseStatusCode);
        Assert.That(_singleOutcodeService.GetStatusCode(), Is.EqualTo(bodyResponseStatusCodeInt));
    }

    [Test]
    public void ObjectStatusInResponseHeader_SameAsResponseBody()
    {
        Assert.That(_singleOutcodeService.GetStatusCode(), Is.EqualTo(_singleOutcodeService.ResponseObject.status));
    }
}
