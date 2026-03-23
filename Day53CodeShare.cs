
  <form asp-action="SetA" method="post">
        <button type="submit" class="btn btn-primary">Set A to 10</button>
    </form>

    <form asp-action="GetA" method="post">
        <button type="submit" class="btn btn-secondary">Get A Value</button>
    </form>

    <p>Value of A: @ViewBag.AValue</p>
