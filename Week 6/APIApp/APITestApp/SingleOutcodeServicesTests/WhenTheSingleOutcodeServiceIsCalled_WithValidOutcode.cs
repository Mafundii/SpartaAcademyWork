using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APITestApp.SingleOutcodeServicesTests;

public class WhenTheSingleOutcodeServiceIsCalled_WithValidOutcode
{
    SingleOutcodeService _SingleOutcodeService;

    [OneTimeSetUp]
    public async Task OneTimeSetUpAsync()
    {
        _SingleOutcodeService = new SingleOutcodeService();
        await _SingleOutcodeService.MakesRequestAsync("EC2Y");
    }

    [Test]
    public void StatusIs200_InJsonResponse()
    {
        Assert.That(_SingleOutcodeService.ResponseContent["status"].ToString(), Is.EqualTo("200"));
    }

    [Test]
    public void StatusIs200()
    {
        Assert.That(_SingleOutcodeService.GetStatusCode(), Is.EqualTo(200));
    }
    [Test]
    public void ObjectStatusIs200()
    {
        Assert.That(_SingleOutcodeService.ResponseObject.status, Is.EqualTo(200));
    }
    [Test]
    public void StatusInResponseHeader_SameAsResponseBody()
    {
        var bodyResponseStatusCode = _SingleOutcodeService.ResponseContent["status"].ToString();
        var bodyResponseStatusCodeInt = Int32.Parse(bodyResponseStatusCode);
        Assert.That(_SingleOutcodeService.GetStatusCode(), Is.EqualTo(bodyResponseStatusCodeInt));
    }

    [Test]
    public void ObjectStatusInResponseHeader_SameAsResponseBody()
    {
        Assert.That(_SingleOutcodeService.GetStatusCode(), Is.EqualTo(_SingleOutcodeService.ResponseObject.status));
    }
}
