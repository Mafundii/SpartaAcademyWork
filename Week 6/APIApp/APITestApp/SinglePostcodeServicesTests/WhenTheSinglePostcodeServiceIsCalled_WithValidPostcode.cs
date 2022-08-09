using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APITestApp.SinglePostcodeServicesTests;

public class WhenTheSinglePostcodeServiceIsCalled_WithValidPostcode
{

    SinglePostcodeService _singlePostcodeService;

    [OneTimeSetUp]
    public async Task OneTimeSetUpAsync()
    {
        _singlePostcodeService = new SinglePostcodeService();
        await _singlePostcodeService.MakesRequestAsync("EC2Y 5AS");
    }

    [Test]
    public void StatusIs200_InJsonResponse()
    {
        Assert.That(_singlePostcodeService.ResponseContent["status"].ToString(), Is.EqualTo("200"));
    }

    [Test]
    public void StatusIs200()
    {
        Assert.That(_singlePostcodeService.GetStatusCode(), Is.EqualTo(200));
    }
    [Test]
    public void ObjectStatusIs200()
    {
        Assert.That(_singlePostcodeService.ResponseObject.status, Is.EqualTo(200));
    }
    [Test]
    public void StatusInResponseHeader_SameAsResponseBody()
    {
        var bodyResponseStatusCode = _singlePostcodeService.ResponseContent["status"].ToString();
        var bodyResponseStatusCodeInt = Int32.Parse(bodyResponseStatusCode);
        Assert.That(_singlePostcodeService.GetStatusCode(), Is.EqualTo(bodyResponseStatusCodeInt));
    }

    [Test]
    public void ObjectStatusInResponseHeader_SameAsResponseBody()
    {
        Assert.That(_singlePostcodeService.GetStatusCode(), Is.EqualTo(_singlePostcodeService.ResponseObject.status));
    }
}