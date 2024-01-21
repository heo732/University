;;;;; TEMPLATES ;;;;;

(deftemplate Testimony (slot name) (slot ifNot) (slot then))
(deftemplate Veracity (slot name) (slot saidTruth))           ; veracity of whos we know in fact at the begin
(deftemplate SupposedThief (slot name))

(deftemplate EndVeracity (slot name) (slot saidTruth))        ; veracity at the end of investigation
(deftemplate TempVeracity (slot name) (slot saidTruth))
(deftemplate Thief (slot name))                               ; thief at the end of investigation


;;;;;;;;;;;;;;;;;



;;;;; FACTS ;;;;;

(deffacts SupposedThiefs
	(SupposedThief (name Ivan))
	(SupposedThief (name Petro))
	(SupposedThief (name Mykola))
	(SupposedThief (name Vasyl))
)

(deffacts Testimonys
	(Testimony (name Ivan) (ifNot Vasyl) (then Petro))    ; said truth
	(Testimony (name Petro) (ifNot Ivan) (then Vasyl))    ; lied        ; thief
	(Testimony (name Mykola) (ifNot Vasyl) (then Ivan))   ; lied
	(Testimony (name Vasyl) (ifNot Petro) (then Vasyl))   ; said truth
)

(deffacts Veracitys
	(Veracity (name Petro) (saidTruth FALSE))
	(Veracity (name Vasyl) (saidTruth TRUE))
)

;;;;;;;;;;;;;;;;;



;;;;; RULES ;;;;;

(defrule R_thief
	?t <- (Thief (name ?name))
	=>
	(printout t "Thief is: " ?name "." crlf)
	(retract ?t)
)

(defrule R_veracity
	?t <- (EndVeracity (name ?name) (saidTruth ?value))
	=>
	(printout t ?name (if ?value then " said truth." else " lied.") crlf)
	(retract ?t)
)

(defrule R_investigation
	(SupposedThief (name ?supposedThief))
	=>
	(bind ?switchForAdd TRUE)
	
	(do-for-all-facts ((?testimony Testimony)) TRUE
		; check lie/truth in testimony
		(bind ?testimonyRes FALSE)
		(if (eq ?testimony:ifNot ?supposedThief)
			then (bind ?testimonyRes TRUE)
			else (if (eq ?testimony:then ?supposedThief)
				then (bind ?testimonyRes TRUE)
			)
		)
		; lie/truth in veracity
		(bind ?veracityRes EMPTY)
		(if (< 0 (length$ (find-all-facts ((?v Veracity)) (eq ?v:name ?testimony:name))))
			then (bind ?veracityRes (fact-slot-value (nth$ 1 (find-all-facts ((?v Veracity)) (eq ?v:name ?testimony:name))) saidTruth))
		)
		(if (eq ?veracityRes EMPTY)
			then (assert (TempVeracity (name ?testimony:name) (saidTruth ?testimonyRes)))
			else (if (not (eq ?testimonyRes ?veracityRes))
				then (bind ?switchForAdd FALSE)				
			)
		)		
	)
	; if find the solution (length TempVeracity = length Testimony - length Veracity)
	(if (and (= (length$ (find-all-facts ((?f TempVeracity)) TRUE)) (- (length$ (find-all-facts ((?f Testimony)) TRUE)) (length$ (find-all-facts ((?f Veracity)) TRUE)))) ?switchForAdd)
		; push TempVeracity into EndVeracity & assert(Thief)
		then 
			(do-for-all-facts ((?tempVeracity TempVeracity)) TRUE (assert (EndVeracity (name ?tempVeracity:name) (saidTruth ?tempVeracity:saidTruth))))
			(assert (Thief (name ?supposedThief)))
	)	

	; retract TempVeracity
	(do-for-all-facts ((?t TempVeracity)) TRUE (retract ?t))
)

;;;;;;;;;;;;;;;;;
