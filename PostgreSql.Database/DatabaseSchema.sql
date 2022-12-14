PGDMP         3                z            productcatalog    14.5    14.5                0    0    ENCODING    ENCODING        SET client_encoding = 'UTF8';
                      false                       0    0 
   STDSTRINGS 
   STDSTRINGS     (   SET standard_conforming_strings = 'on';
                      false                       0    0 
   SEARCHPATH 
   SEARCHPATH     8   SELECT pg_catalog.set_config('search_path', '', false);
                      false                       1262    344858    productcatalog    DATABASE     k   CREATE DATABASE productcatalog WITH TEMPLATE = template0 ENCODING = 'UTF8' LOCALE = 'Turkish_Turkey.1254';
    DROP DATABASE productcatalog;
                postgres    false            ?            1259    344898    hibernate_sequence    SEQUENCE     {   CREATE SEQUENCE public.hibernate_sequence
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 )   DROP SEQUENCE public.hibernate_sequence;
       public          postgres    false            ?            1259    344859 
   tblaccount    TABLE     ?   CREATE TABLE public.tblaccount (
    id integer NOT NULL,
    userid integer,
    productid integer,
    offerid integer,
    isdeleted boolean
);
    DROP TABLE public.tblaccount;
       public         heap    postgres    false            ?            1259    344864    tblcategory    TABLE     ?   CREATE TABLE public.tblcategory (
    id integer NOT NULL,
    categoryname character varying(255) NOT NULL,
    isdeleted boolean
);
    DROP TABLE public.tblcategory;
       public         heap    postgres    false            ?            1259    344869    tbloffer    TABLE     ?   CREATE TABLE public.tbloffer (
    id integer NOT NULL,
    userid integer,
    productid integer,
    isapproved boolean NOT NULL,
    issold boolean NOT NULL,
    offeredprice double precision NOT NULL,
    isdeleted boolean
);
    DROP TABLE public.tbloffer;
       public         heap    postgres    false            ?            1259    344874    tbloperationclaim    TABLE     ?   CREATE TABLE public.tbloperationclaim (
    id integer NOT NULL,
    name character varying(255) NOT NULL,
    isdeleted boolean
);
 %   DROP TABLE public.tbloperationclaim;
       public         heap    postgres    false            ?            1259    344879 
   tblproduct    TABLE     ?  CREATE TABLE public.tblproduct (
    id integer NOT NULL,
    categoryid integer,
    userid integer,
    productname character varying(255) NOT NULL,
    description character varying(255) NOT NULL,
    isofferable boolean NOT NULL,
    issold boolean NOT NULL,
    color character varying(255) NOT NULL,
    brand character varying(255) NOT NULL,
    price double precision NOT NULL,
    isdeleted boolean
);
    DROP TABLE public.tblproduct;
       public         heap    postgres    false            ?            1259    344886    tbluser    TABLE       CREATE TABLE public.tbluser (
    id integer NOT NULL,
    firstname character varying(255) NOT NULL,
    lastname character varying(255) NOT NULL,
    email character varying(255) NOT NULL,
    passwordhash bytea,
    passwordsalt bytea,
    status boolean,
    isdeleted boolean
);
    DROP TABLE public.tbluser;
       public         heap    postgres    false            ?            1259    344893    tbluseroperationclaim    TABLE     ?   CREATE TABLE public.tbluseroperationclaim (
    id integer NOT NULL,
    userid integer NOT NULL,
    operationclaimid integer NOT NULL,
    isdeleted boolean
);
 )   DROP TABLE public.tbluseroperationclaim;
       public         heap    postgres    false            v           2606    344863    tblaccount tblaccount_pkey 
   CONSTRAINT     X   ALTER TABLE ONLY public.tblaccount
    ADD CONSTRAINT tblaccount_pkey PRIMARY KEY (id);
 D   ALTER TABLE ONLY public.tblaccount DROP CONSTRAINT tblaccount_pkey;
       public            postgres    false    209            x           2606    344868    tblcategory tblcategory_pkey 
   CONSTRAINT     Z   ALTER TABLE ONLY public.tblcategory
    ADD CONSTRAINT tblcategory_pkey PRIMARY KEY (id);
 F   ALTER TABLE ONLY public.tblcategory DROP CONSTRAINT tblcategory_pkey;
       public            postgres    false    210            |           2606    344873    tbloffer tbloffer_pkey 
   CONSTRAINT     T   ALTER TABLE ONLY public.tbloffer
    ADD CONSTRAINT tbloffer_pkey PRIMARY KEY (id);
 @   ALTER TABLE ONLY public.tbloffer DROP CONSTRAINT tbloffer_pkey;
       public            postgres    false    211            ~           2606    344878 (   tbloperationclaim tbloperationclaim_pkey 
   CONSTRAINT     f   ALTER TABLE ONLY public.tbloperationclaim
    ADD CONSTRAINT tbloperationclaim_pkey PRIMARY KEY (id);
 R   ALTER TABLE ONLY public.tbloperationclaim DROP CONSTRAINT tbloperationclaim_pkey;
       public            postgres    false    212            ?           2606    344885    tblproduct tblproduct_pkey 
   CONSTRAINT     X   ALTER TABLE ONLY public.tblproduct
    ADD CONSTRAINT tblproduct_pkey PRIMARY KEY (id);
 D   ALTER TABLE ONLY public.tblproduct DROP CONSTRAINT tblproduct_pkey;
       public            postgres    false    213            ?           2606    344892    tbluser tbluser_pkey 
   CONSTRAINT     R   ALTER TABLE ONLY public.tbluser
    ADD CONSTRAINT tbluser_pkey PRIMARY KEY (id);
 >   ALTER TABLE ONLY public.tbluser DROP CONSTRAINT tbluser_pkey;
       public            postgres    false    214            ?           2606    344897 0   tbluseroperationclaim tbluseroperationclaim_pkey 
   CONSTRAINT     n   ALTER TABLE ONLY public.tbluseroperationclaim
    ADD CONSTRAINT tbluseroperationclaim_pkey PRIMARY KEY (id);
 Z   ALTER TABLE ONLY public.tbluseroperationclaim DROP CONSTRAINT tbluseroperationclaim_pkey;
       public            postgres    false    215            t           1259    344928    fki_account_to_user_fk    INDEX     O   CREATE INDEX fki_account_to_user_fk ON public.tblaccount USING btree (userid);
 *   DROP INDEX public.fki_account_to_user_fk;
       public            postgres    false    209            y           1259    344916    fki_offer_to_product_fk    INDEX     Q   CREATE INDEX fki_offer_to_product_fk ON public.tbloffer USING btree (productid);
 +   DROP INDEX public.fki_offer_to_product_fk;
       public            postgres    false    211            z           1259    344922    fki_offer_to_user_fk    INDEX     K   CREATE INDEX fki_offer_to_user_fk ON public.tbloffer USING btree (userid);
 (   DROP INDEX public.fki_offer_to_user_fk;
       public            postgres    false    211                       1259    344904    fki_product_to_category_fk    INDEX     W   CREATE INDEX fki_product_to_category_fk ON public.tblproduct USING btree (categoryid);
 .   DROP INDEX public.fki_product_to_category_fk;
       public            postgres    false    213            ?           1259    344910    fki_product_to_user_fk    INDEX     O   CREATE INDEX fki_product_to_user_fk ON public.tblproduct USING btree (userid);
 *   DROP INDEX public.fki_product_to_user_fk;
       public            postgres    false    213            ?           2606    344923    tblaccount account_to_user_fk    FK CONSTRAINT     ?   ALTER TABLE ONLY public.tblaccount
    ADD CONSTRAINT account_to_user_fk FOREIGN KEY (userid) REFERENCES public.tbluser(id) NOT VALID;
 G   ALTER TABLE ONLY public.tblaccount DROP CONSTRAINT account_to_user_fk;
       public          postgres    false    209    214    3204            ?           2606    344911    tbloffer offer_to_product_fk    FK CONSTRAINT     ?   ALTER TABLE ONLY public.tbloffer
    ADD CONSTRAINT offer_to_product_fk FOREIGN KEY (productid) REFERENCES public.tblproduct(id) NOT VALID;
 F   ALTER TABLE ONLY public.tbloffer DROP CONSTRAINT offer_to_product_fk;
       public          postgres    false    213    211    3202            ?           2606    344917    tbloffer offer_to_user_fk    FK CONSTRAINT     ?   ALTER TABLE ONLY public.tbloffer
    ADD CONSTRAINT offer_to_user_fk FOREIGN KEY (userid) REFERENCES public.tbluser(id) NOT VALID;
 C   ALTER TABLE ONLY public.tbloffer DROP CONSTRAINT offer_to_user_fk;
       public          postgres    false    211    3204    214            ?           2606    344899 !   tblproduct product_to_category_fk    FK CONSTRAINT     ?   ALTER TABLE ONLY public.tblproduct
    ADD CONSTRAINT product_to_category_fk FOREIGN KEY (categoryid) REFERENCES public.tblcategory(id) NOT VALID;
 K   ALTER TABLE ONLY public.tblproduct DROP CONSTRAINT product_to_category_fk;
       public          postgres    false    3192    213    210            ?           2606    344905    tblproduct product_to_user_fk    FK CONSTRAINT     ?   ALTER TABLE ONLY public.tblproduct
    ADD CONSTRAINT product_to_user_fk FOREIGN KEY (userid) REFERENCES public.tbluser(id) NOT VALID;
 G   ALTER TABLE ONLY public.tblproduct DROP CONSTRAINT product_to_user_fk;
       public          postgres    false    214    3204    213           