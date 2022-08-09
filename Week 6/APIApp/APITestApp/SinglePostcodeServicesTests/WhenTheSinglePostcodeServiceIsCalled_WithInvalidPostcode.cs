using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APITestApp.SinglePostcodeServicesTests;

public class WhenTheSinglePostcodeServiceIsCalled_WithInvalidPostcode
{
    SinglePostcodeService _singlePostcodeService;

    [OneTimeSetUp]
    public async Task OneTimeSetUpAsync()
    {
        _singlePostcodeService = new SinglePostcodeService();
        await _singlePostcodeService.MakesRequestAsync("lmao");
    }

    [Test]
    public void StatusIsNot200_InJsonResponse()
    {
        Assert.That(_singlePostcodeService.ResponseContent["status"].ToString(), Is.Not.EqualTo("200"));
    }

    [Test]
    public void StatusIsNot200()
    {
        Assert.That(_singlePostcodeService.GetStatusCode(), Is.Not.EqualTo(200));
    }
    [Test]
    public void ObjectStatusIsNot200()
    {
        Assert.That(_singlePostcodeService.ResponseObject.status, Is.Not.EqualTo(200));
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
