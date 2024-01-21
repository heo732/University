;;;;;;;; FACTS ;;;;;;;;

(deffacts Tovary
	(Tovar apple 20 100 2018 Ukraine)
	(Tovar patatoes 5 1000 2017 Ukraine)
	(Tovar carrot 9 50 2018 Ukraine)
	(Tovar beer 50 3 2018 Czech)
	(Tovar cheese 40 100 2009 Russia)
)

;;;;;;;;;;;;;;;;;;;;;;;



;;;;;;;; GLOBALS ;;;;;;;;

(defglobal
	?*currentYear* = 2010
	?*ourCountry* = empty
	?*number_R_ourCountryGoods_Execute* = 0
	?*number_ourCountryGoods* = 0
)

;;;;;;;;;;;;;;;;;;;;;;;



;;;;;;;; RULES ;;;;;;;;

(defrule R_read_CurrentYear_and_ourCountry
	(initial-fact)
	=>
	(printout t "Input current year: ")
	(bind ?*currentYear* (read) )
	(printout t "Input our country: ")
	(bind ?*ourCountry* (read) )
	(assert (R_read_CurrentYear_and_ourCountry executed) )
)

(defrule R_ucinka
	(R_read_CurrentYear_and_ourCountry executed)
	(Tovar ?name ?price ?count ?year ?country)
	(test (or (< ?year 2010) (< ?count 4) ) )
	=>	
	(assert (Ucinka ?name (* ?price 0.15 ?count) ) )
)

(defrule R_nacinka
	(R_read_CurrentYear_and_ourCountry executed)
	(Tovar ?name ?price ?count ?year ?country)
	(test (not (eq ?country ?*ourCountry*) ) )   ; import goods
	(test (= ?year ?*currentYear*) )			 ; current year
	=>
	(assert (Nacinka ?name (* ?price 0.07 ?count) ) )		
)

(defrule R_ourCountryGoods
	(R_read_CurrentYear_and_ourCountry executed)
	(Tovar ?name ?price ?count ?year ?country)
	=>	
	(bind ?*number_R_ourCountryGoods_Execute* (+ 1 ?*number_R_ourCountryGoods_Execute*) )
	(if (eq ?country ?*ourCountry*)
		then (bind ?*number_ourCountryGoods* (+ 1 ?*number_ourCountryGoods*) )
	)
	(bind ?numberGoods (length$ (find-all-facts ((?f Tovar)) TRUE) ) )
	(if (= ?*number_R_ourCountryGoods_Execute* ?numberGoods)
		then (if (= 0 ?*number_ourCountryGoods*)
			then (printout t "There are not goods made in " ?*ourCountry* "." crlf)
		else (printout t "There are " ?*number_ourCountryGoods* " goods made in " ?*ourCountry* "." crlf)
		)
	)
)

;;;;;;;;;;;;;;;;;;;;;;;
