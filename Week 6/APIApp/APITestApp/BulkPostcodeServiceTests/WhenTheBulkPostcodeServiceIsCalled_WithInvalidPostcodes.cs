using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APITestApp.BulkPostcodeServiceTests;

public class WhenTheBulkPostcodeServiceIsCalled_WithInvalidPostcodes
{
    BulkPostcodeService _BulkPostcodeService;

    [OneTimeSetUp]
    public async Task OneTimeSetUpAsync()
    {
        _BulkPostcodeService = new BulkPostcodeService();
        await _BulkPostcodeService.MakesRequestAsync(new string[] { "lmao", "eee", "" });
    }

    [Test]
    public void StatusIsNot200_InJsonResponse()
    {
        Assert.That(_BulkPostcodeService.ResponseContent["status"].ToString(), Is.EqualTo("200"));
    }

    [Test]
    public void StatusIsNot200()
    {
        Assert.That(_BulkPostcodeService.GetStatusCode(), Is.EqualTo(200));
    }
    [Test]
    public void ObjectStatusIsNot200()
    {
        Assert.That(_BulkPostcodeService.ResponseObject.status, Is.EqualTo(200));
    }

    [Test]
    public void ObjectQueryResultIsNull()
    {
        Assert.That(_BulkPostcodeService.ResponseObject.result[0].result, Is.Null);
        Assert.That(_BulkPostcodeService.ResponseObject.result[1].result, Is.Null);
        Assert.That(_BulkPostcodeService.ResponseObject.result[2].result, Is.Null);
    }

    [Test]
    public void StatusInResponseHeader_SameAsResponseBody()
    {
        var bodyResponseStatusCode = _BulkPostcodeService.ResponseContent["status"].ToString();
        var bodyResponseStatusCodeInt = Int32.Parse(bodyResponseStatusCode);
        Assert.That(_BulkPostcodeService.GetStatusCode(), Is.EqualTo(bodyResponseStatusCodeInt));
    }

    [Test]
    public void ObjectStatusInResponseHeader_SameAsResponseBody()
    {
        Assert.That(_BulkPostcodeService.GetStatusCode(), Is.EqualTo(_BulkPostcodeService.ResponseObject.status));
    }
}
