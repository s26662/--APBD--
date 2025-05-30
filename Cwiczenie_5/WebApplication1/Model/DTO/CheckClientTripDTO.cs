﻿namespace WebApplication1.Model.DTO;

public class CheckClientTripDTO
{
    public int IdClient { get; set; }
    public int IdTrip { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime DateFrom { get; set; }
    public DateTime DateTo { get; set; }
    public int MaxPeople { get; set; }
    public int RegisteredAt { get; set; }
    public int? PaymentDate { get; set; }
    public List<CountryInfoDTO> Countries { get; set; }
}