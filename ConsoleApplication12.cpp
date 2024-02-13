#include <iostream>
#include <vector>;
using namespace std;

class Munkavallalo {

private:
    string nev;
    Munkavallalo* fonok;
    double fizetes;

public:
    Munkavallalo(string nev, Munkavallalo* fonok, double fizetes) {
        this->nev = nev;
        this->fonok = fonok;
        this->fizetes = fizetes;
    }

    string getNev() { return nev; }
    Munkavallalo* getfonok() { return fonok; }
    double getFizetes() { return fizetes; }
};

class MunkavallaloKontener
{
private:
    vector<Munkavallalo> munkasok;
public:
    void ujMunkavallalo(Munkavallalo munkas) {
        munkasok.push_back(munkas);
    }

    double atlagFizetes() {
        int db = 0;
        double sum = 0;

        for (auto i = munkasok.begin(); i != munkasok.end(); i++)
        {
            db++;
            sum += (*i).getFizetes();
        }

        if (sum==0)
        {
            return 0;
        }

        return sum / db;
    }

    int hanyFonokVan() {

        int db = 0;

        for (auto i = munkasok.begin(); i != munkasok.end(); i++)
        {
            if ((*i).getfonok() == NULL)
            {
                db++;
            }
        }
        if (db==0)
        {
            return 0;
        }
        return db;
    }


};



int main()
{
    Munkavallalo dn = Munkavallalo("Deez", NULL, 15000);
    Munkavallalo dn1 = Munkavallalo("Deez1", &dn, 1000);
    MunkavallaloKontener dolgozok;
    dolgozok.ujMunkavallalo(dn);
    dolgozok.ujMunkavallalo(dn1);
    

    cout << dolgozok.hanyFonokVan() << " fonok van" << endl;
    cout << dolgozok.atlagFizetes() << " atlag fizetes" << endl;
    

}