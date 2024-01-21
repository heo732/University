//---------------------------------------------------------------------------
#ifndef unitTask1H
#define unitTask1H
#include <Classes.hpp>
#include <time.h>
#include <ExtCtrls.hpp>
#include <Forms.hpp>
//---------------------------------------------------------------------------
class Card
{
        public:

        enum Suit
        {
                hearts,
                diamonds,
                clubs,
                spades
        };

        enum Rank
        {
                six,
                seven,
                eight,
                nine,
                ten,
                jack,
                queen,
                king,
                ace
        };

        private:

        Suit suit;
        Rank rank;

        public:

        Card()
        {
                suit = hearts;
                rank = ace;
        }

        Card(Suit s, Rank r) : suit(s), rank(r) {}
        
        Suit getSuit()
        {
                return suit;
        }

        Rank getRank()
        {
                return rank;
        }

        void setSuit(Suit s)
        {
                suit = s;
        }

        void setRank(Rank r)
        {
                rank = r;
        }

        Card& operator = (Card c)
        {
                suit = c.suit;
                rank = c.rank;
                return *this;
        }

        Card& operator = (Suit s)
        {
                suit = s;
                return *this;
        }

        Card& operator = (Rank r)
        {
                rank = r;
                return *this;
        }
};
//---------------------------------------------------------------------------
class Deck
{
        protected:

        int countCards;
        Card *cards;

        public:

        int getCountCards()
        {
                return countCards;
        }

        void getCards(int count)
        {
                if(cards != NULL)
                {
                        delete cards;
                        cards = NULL;
                }        

                if(count > 0)
                {
                        cards = new Card[count];
                        countCards = count;
                }
                else
                {
                        cards = new Card[36];
                        countCards = 36;
                }

                Card::Suit s = Card::hearts;
                Card::Rank r = Card::six;
                for(int i = 0; i < countCards; i++)
                {
                        cards[i] = s;
                        cards[i] = r;
                        switch(s)
                        {
                                case Card::hearts:
                                        s = Card::diamonds;
                                        break;
                                case Card::diamonds:
                                        s = Card::clubs;
                                        break;
                                case Card::clubs:
                                        s = Card::spades;
                                        break;
                                case Card::spades:
                                        if(r == Card::ace)
                                        {
                                                s = Card::hearts;
                                                r = Card::six;
                                        }
                                        else
                                        {
                                                s = Card::hearts;
                                                switch(r)
                                                {
                                                        case Card::six:
                                                                r = Card::seven;
                                                                break;
                                                        case Card::seven:
                                                                r = Card::eight;
                                                                break;
                                                        case Card::eight:
                                                                r = Card::nine;
                                                                break;
                                                        case Card::nine:
                                                                r = Card::ten;
                                                                break;
                                                        case Card::ten:
                                                                r = Card::jack;
                                                                break;
                                                        case Card::jack:
                                                                r = Card::queen;
                                                                break;
                                                        case Card::queen:
                                                                r = Card::king;
                                                                break;
                                                        case Card::king:
                                                                r = Card::ace;
                                                                break;
                                                }
                                        }
                                        break;
                        }
                }
        }

        void shuffleCards()
        {
                for(int i = 0; i < countCards; i++)
                {
                        double r = (double) rand() / (double) RAND_MAX;
                        r *= countCards;
                        int j = (int) r;
                        Card temp = cards[i];
                        cards[i] = cards[j];
                        cards[j] = temp;
                }
        }

        Deck()
        {
                cards = NULL;
                getCards(36);
                shuffleCards();
        }

        Deck(int count)
        {
                cards = NULL;
                getCards(count);
                shuffleCards();
        }

        ~Deck()
        {
                if(cards != NULL)
                {
                        delete cards;
                        cards = NULL;
                }       
        }
};
//---------------------------------------------------------------------------
class ConsistentDeck : public Deck
{
        public:

        ConsistentDeck() : Deck() {}
        ConsistentDeck(int count) : Deck(count) {}
        ~ConsistentDeck() {}

        Card getCard()
        {
                countCards--;
                return cards[countCards];
        }
};
//---------------------------------------------------------------------------
class FreeDeck : public Deck
{
        public:

        FreeDeck() : Deck() {}
        FreeDeck(int count) : Deck(count) {}
        ~FreeDeck() {}

        Card getCard(int index)
        {
                if(index < 0 || index >= countCards)
                {
                        countCards--;
                        return cards[countCards];
                }
                else
                {
                        Card c = cards[index];
                        for(int i = index; i < countCards-1; i++)
                                cards[i] = cards[i+1];
                        countCards--;        
                        return c;
                }
        }
};
//---------------------------------------------------------------------------
class Game
{
        private:

        FreeDeck fDeck1, fDeck2;
        ConsistentDeck cDeck1, cDeck2;
        int gameSteps;
        int currentStep;
        char gameStatus; //-1 - isNotBeginYet, 0 - gameOver, 1 - firstPlayer, 2 - secondPlayer
        int score1, score2;
        Card lastCardPlayer1;

        TImage *imageConsistentDeck1;
        TImage *imageConsistentDeck2;
        TImage *imageFreeDeck1;
        TImage *imageFreeDeck2;
        TImage *imageCurrentCard1;
        TImage *imageCurrentCard2;
        TLabel *labelCountPoints1;
        TLabel *labelCountPoints2;
        TLabel *labelStatus;

        public:

        Game()
        {
                srand(time(0));
                gameSteps = 10;
                currentStep = 0;
                gameStatus = -1;
                lastCardPlayer1.setSuit(Card::diamonds);
                lastCardPlayer1.setRank(Card::six);
        }

        ~Game() {}

        void startGame(TImage *imgCDeck1, TImage *imgCDeck2,
        TImage *imgFDeck1, TImage *imgFDeck2, TImage *imgCurrentCard1,
        TImage *imgCurrentCard2, int cntSteps, TLabel *lGStatus,
        TLabel *lP1Score, TLabel *lP2Score)
        {
                imgCDeck1->Picture->LoadFromFile("cards/consistentDeck.bmp");
                imgCDeck2->Picture->LoadFromFile("cards/consistentDeck.bmp");
                imgFDeck1->Picture->LoadFromFile("cards/freeDeck.bmp");
                imgFDeck2->Picture->LoadFromFile("cards/freeDeck.bmp");
                imgCurrentCard1->Canvas->Pen->Color = clWhite;
                imgCurrentCard1->Canvas->Brush->Color = clWhite;
                imgCurrentCard1->Canvas->Rectangle(0,0,imgCurrentCard1->Width,imgCurrentCard1->Height);
                imgCurrentCard2->Canvas->Pen->Color = clWhite;
                imgCurrentCard2->Canvas->Brush->Color = clWhite;
                imgCurrentCard2->Canvas->Rectangle(0,0,imgCurrentCard2->Width,imgCurrentCard2->Height);
                gameSteps = cntSteps;
                currentStep = 0;
                gameStatus = 1;
                cDeck1.getCards(36);
                cDeck2.getCards(36);
                fDeck1.getCards(36);
                fDeck2.getCards(36);
                cDeck1.shuffleCards();
                cDeck2.shuffleCards();
                fDeck1.shuffleCards();
                fDeck2.shuffleCards();
                imgCDeck2->Enabled = false;
                imgFDeck2->Enabled = false;
                imgCDeck1->Enabled = true;
                imgFDeck1->Enabled = true;
                lP1Score->Caption = "0";
                lP2Score->Caption = "0";
                lGStatus->Caption = "Зараз ходить: Гравець_1";
                imageConsistentDeck1 = imgCDeck1;
                imageConsistentDeck2 = imgCDeck2;
                imageFreeDeck1 = imgFDeck1;
                imageFreeDeck2 = imgFDeck2;
                this->imageCurrentCard1 = imgCurrentCard1;
                this->imageCurrentCard2 = imgCurrentCard2;
                labelStatus = lGStatus;
                labelCountPoints1 = lP1Score;
                labelCountPoints2 = lP2Score;
                score1 = score2 = 0;
        }

        enum Step
        {
                consistent,
                free
        };

        void doStep(Step step, int Y, TImage *img)
        {
                switch(gameStatus)
                {
                case 1:
                {
                        Card c;
                        switch(step)
                        {
                        case Game::consistent:
                                if(cDeck1.getCountCards() > 0)
                                {
                                     c = cDeck1.getCard();
                                }
                                else
                                {
                                     cDeck1.getCards(36);
                                     cDeck1.shuffleCards();
                                     c = cDeck1.getCard();
                                }
                                break;
                        case Game::free:
                                if(fDeck1.getCountCards() > 0)
                                {
                                     c = fDeck1.getCard((int)((Y/img->Height)*fDeck1.getCountCards()));
                                }
                                else
                                {
                                     fDeck1.getCards(36);
                                     fDeck1.shuffleCards();
                                     c = fDeck1.getCard((int)((Y/img->Height)*fDeck1.getCountCards()));
                                }
                                break;
                        }
                        gameStatus = 2;
                        imageConsistentDeck1->Enabled = false;
                        imageFreeDeck1->Enabled = false;
                        imageConsistentDeck2->Enabled = true;
                        imageFreeDeck2->Enabled = true;
                        labelStatus->Caption = "Зараз ходить: Гравець_2";

                        String strRank, strSuite;
                        switch(c.getRank())
                        {
                        case Card::six:
                                strRank = "six";
                                break;
                        case Card::seven:
                                strRank = "seven";
                                break;
                        case Card::eight:
                                strRank = "eight";
                                break;
                        case Card::nine:
                                strRank = "nine";
                                break;
                        case Card::ten:
                                strRank = "ten";
                                break;
                        case Card::jack:
                                strRank = "jack";
                                break;
                        case Card::queen:
                                strRank = "queen";
                                break;
                        case Card::king:
                                strRank = "king";
                                break;
                        case Card::ace:
                                strRank = "ace";
                                break;
                        }
                        switch(c.getSuit())
                        {
                        case Card::hearts:
                                strSuite = "Hearts";
                                break;
                        case Card::diamonds:
                                strSuite = "Diamonds";
                                break;
                        case Card::clubs:
                                strSuite = "Clubs";
                                break;
                        case Card::spades:
                                strSuite = "Spades";
                                break;
                        }
                        imageCurrentCard1->Picture->LoadFromFile("cards/"+strRank+strSuite+".bmp");
                        lastCardPlayer1 = c;
                        break;
                }
                case 2:
                {
                        Card c;
                        switch(step)
                        {
                        case Game::consistent:
                                if(cDeck2.getCountCards() > 0)
                                {
                                     c = cDeck2.getCard();
                                }
                                else
                                {
                                     cDeck2.getCards(36);
                                     cDeck2.shuffleCards();
                                     c = cDeck2.getCard();
                                }
                                break;
                        case Game::free:
                                if(fDeck2.getCountCards() > 0)
                                {
                                     c = fDeck2.getCard((int)((Y/img->Height)*fDeck2.getCountCards()));
                                }
                                else
                                {
                                     fDeck2.getCards(36);
                                     fDeck2.shuffleCards();
                                     c = fDeck2.getCard((int)((Y/img->Height)*fDeck2.getCountCards()));
                                }
                                break;
                        }

                        String strRank, strSuite;
                        switch(c.getRank())
                        {
                        case Card::six:
                                strRank = "six";
                                break;
                        case Card::seven:
                                strRank = "seven";
                                break;
                        case Card::eight:
                                strRank = "eight";
                                break;
                        case Card::nine:
                                strRank = "nine";
                                break;
                        case Card::ten:
                                strRank = "ten";
                                break;
                        case Card::jack:
                                strRank = "jack";
                                break;
                        case Card::queen:
                                strRank = "queen";
                                break;
                        case Card::king:
                                strRank = "king";
                                break;
                        case Card::ace:
                                strRank = "ace";
                                break;
                        }
                        switch(c.getSuit())
                        {
                        case Card::hearts:
                                strSuite = "Hearts";
                                break;
                        case Card::diamonds:
                                strSuite = "Diamonds";
                                break;
                        case Card::clubs:
                                strSuite = "Clubs";
                                break;
                        case Card::spades:
                                strSuite = "Spades";
                                break;
                        }
                        imageCurrentCard2->Picture->LoadFromFile("cards/"+strRank+strSuite+".bmp");

                        if(lastCardPlayer1.getRank() > c.getRank())
                        {
                                score1++;
                                labelCountPoints1->Caption = IntToStr(score1);
                        }
                        else if(lastCardPlayer1.getRank() < c.getRank())
                        {
                                score2++;
                                labelCountPoints2->Caption = IntToStr(score2);
                        }

                        currentStep++;

                        if(currentStep >= gameSteps)
                        {
                                gameStatus = 0;
                                imageConsistentDeck1->Enabled = false;
                                imageFreeDeck1->Enabled = false;
                                imageConsistentDeck2->Enabled = false;
                                imageFreeDeck2->Enabled = false;
                                if(score1 == score2)
                                        labelStatus->Caption = "Нічия";
                                else if(score1 > score2)
                                        labelStatus->Caption = "Гравець_1 виграв!";
                                else
                                        labelStatus->Caption = "Гравець_2 виграв!";                
                        }
                        else
                        {
                                gameStatus = 1;
                                imageConsistentDeck1->Enabled = true;
                                imageFreeDeck1->Enabled = true;
                                imageConsistentDeck2->Enabled = false;
                                imageFreeDeck2->Enabled = false;
                                labelStatus->Caption = "Зараз ходить: Гравець_1";
                        }

                        break;
                }
                }
        }

};
//---------------------------------------------------------------------------
#endif
