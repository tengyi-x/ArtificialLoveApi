[HttpPost("compare-bios")]
public async Task<IActionResult> CompareBios([FromBody] BioRequest request)
{
    string compatibility = await CheckCompatibilityAsync(request.Bio1, request.Bio2);
    return Ok(new { compatibility });
}

public class BioRequest
{
    public string Bio1 { get; set; }
    public string Bio2 { get; set; }
}