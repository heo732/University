;;;;;;;; FACTS ;;;;;;;;

(deffacts Employees
	(Employee Lupul 25 4 15000)
	(Employee Kikabidze 15 2 12000)
	(Employee Grynevych 8 0 8000)
	(Employee Jajcenjuh 10 0 5000)
	(Employee Prytrushenko 3 3 3000)
)

;;;;;;;;;;;;;;;;;;;;;;;



;;;;;;;; GLOBALS ;;;;;;;;

(defglobal
	?*numberPremiaExecute* = 0     ; how many employees was execute for premia
	?*numberVeteranExecute* = 0    ; how many employees was execute for veteran
	?*numberVeteran* = 0           ; how many employees are veterans of work
)

;;;;;;;;;;;;;;;;;;;;;;;



;;;;;;;; RULES ;;;;;;;;

(defrule R_setPremia
	(Employee ?surname ?experience ?children ?salary)
	(test (or (>= ?experience 5) (> ?children 2) ) )
	(test (bind ?*numberPremiaExecute* (+ ?*numberPremiaExecute* 1) ) )           ; numberPremiaExecute++
	=>		
	(assert (Premia ?surname (* ?salary 0.2) ) )
)

(defrule R_checkPremia
	(test(= ?*numberPremiaExecute* (length$ (find-all-facts ((?f Employee)) TRUE) ) ) )   ; premia executions is equal number of employees
	=>	
	(bind ?numberEmployee (length$ (find-all-facts ((?f Employee)) TRUE) ) )
	(bind ?numberPremia (length$ (find-all-facts ((?f Premia)) TRUE) ) )	
	(if (= ?numberPremia ?numberEmployee)
		then (printout t "All employees received premia." crlf) 
	else
		(printout t "Not all employees received premia." crlf) 
	)
)

(defrule R_checkVeteran
	(Employee ?surname ?experience ?children ?salary)
	=>	
	(bind ?numberEmployee (length$ (find-all-facts ((?f Employee)) TRUE) ) )
	(bind ?*numberVeteranExecute* (+ ?*numberVeteranExecute* 1))           ; numberVeteranExecute++
	(if (> ?experience 20)
		then (bind ?*numberVeteran* (+ ?*numberVeteran* 1))
	)
	(if (= ?numberEmployee ?*numberVeteranExecute*)
		then (if (= 0 ?*numberVeteran*)
				then (printout t "There are not veterans of work." crlf)
			else
				(printout t "There are " ?*numberVeteran* "  veterans of work." crlf)
		)
	)
)

;;;;;;;;;;;;;;;;;;;;;;;
