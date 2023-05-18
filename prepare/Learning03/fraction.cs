class Fraction {
    private int _upper;
    private int _lower;

    public Fraction() {
        _upper = 1;
        _lower = 1;
    }
    public Fraction(int upper) {
        _upper = upper;
        _lower = 1;
    }
    public Fraction(int upper, int lower) {
        _upper = upper;
        _lower = lower;
    }

    public int GetUpper (){
        return _upper;
    }
    public int getLower (){
        return _lower;
    }

    public void SetUpper (int upper){
        _upper = upper;
    }
    public void SetLower (int lower){
        _lower = lower;
    }

    public string GetFractionString(){
        return $"{_upper}/{_lower}";
    }

    public double GetDeciamalValue(){
        return (double)_upper/(double)_lower;
    }


}