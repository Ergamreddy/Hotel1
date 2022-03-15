--
-- PostgreSQL database dump
--

-- Dumped from database version 13.6
-- Dumped by pg_dump version 13.6

SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SELECT pg_catalog.set_config('search_path', '', false);
SET check_function_bodies = false;
SET xmloption = content;
SET client_min_messages = warning;
SET row_security = off;

SET default_tablespace = '';

SET default_table_access_method = heap;

--
-- Name: guest; Type: TABLE; Schema: public; Owner: task1_admin
--

CREATE TABLE public.guest (
    guest_id bigint NOT NULL,
    first_name character varying NOT NULL,
    last_name character varying NOT NULL,
    mobile bigint NOT NULL,
    address character varying NOT NULL,
    gender integer NOT NULL
);


ALTER TABLE public.guest OWNER TO task1_admin;

--
-- Name: guest_guest_id_seq; Type: SEQUENCE; Schema: public; Owner: task1_admin
--

CREATE SEQUENCE public.guest_guest_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.guest_guest_id_seq OWNER TO task1_admin;

--
-- Name: guest_guest_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: task1_admin
--

ALTER SEQUENCE public.guest_guest_id_seq OWNED BY public.guest.guest_id;


--
-- Name: rooms; Type: TABLE; Schema: public; Owner: task1_admin
--

CREATE TABLE public.rooms (
    room_id bigint NOT NULL,
    facilities character varying NOT NULL,
    price numeric NOT NULL,
    staff_id bigint NOT NULL,
    size integer NOT NULL,
    room_type character varying
);


ALTER TABLE public.rooms OWNER TO task1_admin;

--
-- Name: room_room_id_seq; Type: SEQUENCE; Schema: public; Owner: task1_admin
--

CREATE SEQUENCE public.room_room_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.room_room_id_seq OWNER TO task1_admin;

--
-- Name: room_room_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: task1_admin
--

ALTER SEQUENCE public.room_room_id_seq OWNED BY public.rooms.room_id;


--
-- Name: schedule; Type: TABLE; Schema: public; Owner: task1_admin
--

CREATE TABLE public.schedule (
    schedule_id bigint NOT NULL,
    check_in date NOT NULL,
    check_out date NOT NULL,
    guest_count integer NOT NULL,
    guest_id bigint NOT NULL,
    room_id bigint NOT NULL
);


ALTER TABLE public.schedule OWNER TO task1_admin;

--
-- Name: schedule_id_seq; Type: SEQUENCE; Schema: public; Owner: task1_admin
--

CREATE SEQUENCE public.schedule_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.schedule_id_seq OWNER TO task1_admin;

--
-- Name: schedule_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: task1_admin
--

ALTER SEQUENCE public.schedule_id_seq OWNED BY public.schedule.schedule_id;


--
-- Name: staff; Type: TABLE; Schema: public; Owner: task1_admin
--

CREATE TABLE public.staff (
    staff_id bigint NOT NULL,
    name character varying NOT NULL,
    gender integer NOT NULL,
    mobile bigint NOT NULL,
    shift integer NOT NULL,
    "position" character varying NOT NULL
);


ALTER TABLE public.staff OWNER TO task1_admin;

--
-- Name: staff_staff_id_seq; Type: SEQUENCE; Schema: public; Owner: task1_admin
--

CREATE SEQUENCE public.staff_staff_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.staff_staff_id_seq OWNER TO task1_admin;

--
-- Name: staff_staff_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: task1_admin
--

ALTER SEQUENCE public.staff_staff_id_seq OWNED BY public.staff.staff_id;


--
-- Name: guest guest_id; Type: DEFAULT; Schema: public; Owner: task1_admin
--

ALTER TABLE ONLY public.guest ALTER COLUMN guest_id SET DEFAULT nextval('public.guest_guest_id_seq'::regclass);


--
-- Name: rooms room_id; Type: DEFAULT; Schema: public; Owner: task1_admin
--

ALTER TABLE ONLY public.rooms ALTER COLUMN room_id SET DEFAULT nextval('public.room_room_id_seq'::regclass);


--
-- Name: schedule schedule_id; Type: DEFAULT; Schema: public; Owner: task1_admin
--

ALTER TABLE ONLY public.schedule ALTER COLUMN schedule_id SET DEFAULT nextval('public.schedule_id_seq'::regclass);


--
-- Name: staff staff_id; Type: DEFAULT; Schema: public; Owner: task1_admin
--

ALTER TABLE ONLY public.staff ALTER COLUMN staff_id SET DEFAULT nextval('public.staff_staff_id_seq'::regclass);


--
-- Data for Name: guest; Type: TABLE DATA; Schema: public; Owner: task1_admin
--

COPY public.guest (guest_id, first_name, last_name, mobile, address, gender) FROM stdin;
0	string	string	0	string	0
2	ruchi	ergamreddy	21343651465	hyd	2
1	rasi	reddy	1325	dsnr	1
3	string	string	0	string	2
\.


--
-- Data for Name: rooms; Type: TABLE DATA; Schema: public; Owner: task1_admin
--

COPY public.rooms (room_id, facilities, price, staff_id, size, room_type) FROM stdin;
1	one	2000	1	300	\N
2	string	0	1	0	string
\.


--
-- Data for Name: schedule; Type: TABLE DATA; Schema: public; Owner: task1_admin
--

COPY public.schedule (schedule_id, check_in, check_out, guest_count, guest_id, room_id) FROM stdin;
1	2022-03-15	2022-03-15	2	1	1
\.


--
-- Data for Name: staff; Type: TABLE DATA; Schema: public; Owner: task1_admin
--

COPY public.staff (staff_id, name, gender, mobile, shift, "position") FROM stdin;
1	ruchi	2	4215435	2	tyudh
\.


--
-- Name: guest_guest_id_seq; Type: SEQUENCE SET; Schema: public; Owner: task1_admin
--

SELECT pg_catalog.setval('public.guest_guest_id_seq', 1, false);


--
-- Name: room_room_id_seq; Type: SEQUENCE SET; Schema: public; Owner: task1_admin
--

SELECT pg_catalog.setval('public.room_room_id_seq', 1, false);


--
-- Name: schedule_id_seq; Type: SEQUENCE SET; Schema: public; Owner: task1_admin
--

SELECT pg_catalog.setval('public.schedule_id_seq', 1, false);


--
-- Name: staff_staff_id_seq; Type: SEQUENCE SET; Schema: public; Owner: task1_admin
--

SELECT pg_catalog.setval('public.staff_staff_id_seq', 1, false);


--
-- Name: guest guest_pkey; Type: CONSTRAINT; Schema: public; Owner: task1_admin
--

ALTER TABLE ONLY public.guest
    ADD CONSTRAINT guest_pkey PRIMARY KEY (guest_id);


--
-- Name: rooms room_pkey; Type: CONSTRAINT; Schema: public; Owner: task1_admin
--

ALTER TABLE ONLY public.rooms
    ADD CONSTRAINT room_pkey PRIMARY KEY (room_id);


--
-- Name: schedule schedule_pkey; Type: CONSTRAINT; Schema: public; Owner: task1_admin
--

ALTER TABLE ONLY public.schedule
    ADD CONSTRAINT schedule_pkey PRIMARY KEY (schedule_id);


--
-- Name: staff staff_pkey; Type: CONSTRAINT; Schema: public; Owner: task1_admin
--

ALTER TABLE ONLY public.staff
    ADD CONSTRAINT staff_pkey PRIMARY KEY (staff_id);


--
-- Name: schedule guest_id; Type: FK CONSTRAINT; Schema: public; Owner: task1_admin
--

ALTER TABLE ONLY public.schedule
    ADD CONSTRAINT guest_id FOREIGN KEY (guest_id) REFERENCES public.guest(guest_id) NOT VALID;


--
-- Name: schedule room_id; Type: FK CONSTRAINT; Schema: public; Owner: task1_admin
--

ALTER TABLE ONLY public.schedule
    ADD CONSTRAINT room_id FOREIGN KEY (room_id) REFERENCES public.rooms(room_id) NOT VALID;


--
-- Name: rooms staff_id; Type: FK CONSTRAINT; Schema: public; Owner: task1_admin
--

ALTER TABLE ONLY public.rooms
    ADD CONSTRAINT staff_id FOREIGN KEY (staff_id) REFERENCES public.staff(staff_id) NOT VALID;


--
-- Name: SCHEMA public; Type: ACL; Schema: -; Owner: postgres
--

GRANT USAGE ON SCHEMA public TO task1_admin;


--
-- PostgreSQL database dump complete
--

