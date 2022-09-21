PGDMP     $                    z            productcatalog    14.5    14.5 %    !           0    0    ENCODING    ENCODING        SET client_encoding = 'UTF8';
                      false            "           0    0 
   STDSTRINGS 
   STDSTRINGS     (   SET standard_conforming_strings = 'on';
                      false            #           0    0 
   SEARCHPATH 
   SEARCHPATH     8   SELECT pg_catalog.set_config('search_path', '', false);
                      false            $           1262    337096    productcatalog    DATABASE     k   CREATE DATABASE productcatalog WITH TEMPLATE = template0 ENCODING = 'UTF8' LOCALE = 'Turkish_Turkey.1254';
    DROP DATABASE productcatalog;
                postgres    false            �            1259    337136    hibernate_sequence    SEQUENCE     {   CREATE SEQUENCE public.hibernate_sequence
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 )   DROP SEQUENCE public.hibernate_sequence;
       public          postgres    false            �            1259    337097 
   tblaccount    TABLE     �   CREATE TABLE public.tblaccount (
    id integer NOT NULL,
    userid integer,
    productid integer,
    offerid integer,
    isdeleted boolean
);
    DROP TABLE public.tblaccount;
       public         heap    postgres    false            �            1259    337102    tblcategory    TABLE     �   CREATE TABLE public.tblcategory (
    id integer NOT NULL,
    categoryname character varying(255) NOT NULL,
    isdeleted boolean
);
    DROP TABLE public.tblcategory;
       public         heap    postgres    false            �            1259    337107    tbloffer    TABLE     �   CREATE TABLE public.tbloffer (
    id integer NOT NULL,
    userid integer,
    productid integer,
    isapproved boolean NOT NULL,
    issold boolean NOT NULL,
    offeredprice double precision NOT NULL,
    isdeleted boolean
);
    DROP TABLE public.tbloffer;
       public         heap    postgres    false            �            1259    337112    tbloperationclaim    TABLE     �   CREATE TABLE public.tbloperationclaim (
    id integer NOT NULL,
    name character varying(255) NOT NULL,
    isdeleted boolean
);
 %   DROP TABLE public.tbloperationclaim;
       public         heap    postgres    false            �            1259    337117 
   tblproduct    TABLE     �  CREATE TABLE public.tblproduct (
    id integer NOT NULL,
    categoryid integer,
    userid integer,
    offerid integer,
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
       public         heap    postgres    false            �            1259    337124    tbluser    TABLE       CREATE TABLE public.tbluser (
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
       public         heap    postgres    false            �            1259    337131    tbluseroperationclaim    TABLE     �   CREATE TABLE public.tbluseroperationclaim (
    id integer NOT NULL,
    userid integer NOT NULL,
    operationclaimid integer NOT NULL,
    isdeleted boolean
);
 )   DROP TABLE public.tbluseroperationclaim;
       public         heap    postgres    false            w           2606    337101    tblaccount tblaccount_pkey 
   CONSTRAINT     X   ALTER TABLE ONLY public.tblaccount
    ADD CONSTRAINT tblaccount_pkey PRIMARY KEY (id);
 D   ALTER TABLE ONLY public.tblaccount DROP CONSTRAINT tblaccount_pkey;
       public            postgres    false    209            y           2606    337106    tblcategory tblcategory_pkey 
   CONSTRAINT     Z   ALTER TABLE ONLY public.tblcategory
    ADD CONSTRAINT tblcategory_pkey PRIMARY KEY (id);
 F   ALTER TABLE ONLY public.tblcategory DROP CONSTRAINT tblcategory_pkey;
       public            postgres    false    210            }           2606    337111    tbloffer tbloffer_pkey 
   CONSTRAINT     T   ALTER TABLE ONLY public.tbloffer
    ADD CONSTRAINT tbloffer_pkey PRIMARY KEY (id);
 @   ALTER TABLE ONLY public.tbloffer DROP CONSTRAINT tbloffer_pkey;
       public            postgres    false    211                       2606    337116 (   tbloperationclaim tbloperationclaim_pkey 
   CONSTRAINT     f   ALTER TABLE ONLY public.tbloperationclaim
    ADD CONSTRAINT tbloperationclaim_pkey PRIMARY KEY (id);
 R   ALTER TABLE ONLY public.tbloperationclaim DROP CONSTRAINT tbloperationclaim_pkey;
       public            postgres    false    212            �           2606    337123    tblproduct tblproduct_pkey 
   CONSTRAINT     X   ALTER TABLE ONLY public.tblproduct
    ADD CONSTRAINT tblproduct_pkey PRIMARY KEY (id);
 D   ALTER TABLE ONLY public.tblproduct DROP CONSTRAINT tblproduct_pkey;
       public            postgres    false    213            �           2606    337130    tbluser tbluser_pkey 
   CONSTRAINT     R   ALTER TABLE ONLY public.tbluser
    ADD CONSTRAINT tbluser_pkey PRIMARY KEY (id);
 >   ALTER TABLE ONLY public.tbluser DROP CONSTRAINT tbluser_pkey;
       public            postgres    false    214            �           2606    337135 0   tbluseroperationclaim tbluseroperationclaim_pkey 
   CONSTRAINT     n   ALTER TABLE ONLY public.tbluseroperationclaim
    ADD CONSTRAINT tbluseroperationclaim_pkey PRIMARY KEY (id);
 Z   ALTER TABLE ONLY public.tbluseroperationclaim DROP CONSTRAINT tbluseroperationclaim_pkey;
       public            postgres    false    215            t           1259    337154    fki_account_to_product_fk    INDEX     U   CREATE INDEX fki_account_to_product_fk ON public.tblaccount USING btree (productid);
 -   DROP INDEX public.fki_account_to_product_fk;
       public            postgres    false    209            u           1259    337148    fki_account_to_user_fk    INDEX     O   CREATE INDEX fki_account_to_user_fk ON public.tblaccount USING btree (userid);
 *   DROP INDEX public.fki_account_to_user_fk;
       public            postgres    false    209            z           1259    337166    fki_offet_to_product_fk    INDEX     Q   CREATE INDEX fki_offet_to_product_fk ON public.tbloffer USING btree (productid);
 +   DROP INDEX public.fki_offet_to_product_fk;
       public            postgres    false    211            {           1259    337160    fki_offet_to_user_fk    INDEX     K   CREATE INDEX fki_offet_to_user_fk ON public.tbloffer USING btree (userid);
 (   DROP INDEX public.fki_offet_to_user_fk;
       public            postgres    false    211            �           1259    337142    fki_product_to_category_fk    INDEX     W   CREATE INDEX fki_product_to_category_fk ON public.tblproduct USING btree (categoryid);
 .   DROP INDEX public.fki_product_to_category_fk;
       public            postgres    false    213            �           1259    337178    fki_product_to_offer_fk    INDEX     Q   CREATE INDEX fki_product_to_offer_fk ON public.tblproduct USING btree (offerid);
 +   DROP INDEX public.fki_product_to_offer_fk;
       public            postgres    false    213            �           1259    337172    fki_product_to_user_fk    INDEX     O   CREATE INDEX fki_product_to_user_fk ON public.tblproduct USING btree (userid);
 *   DROP INDEX public.fki_product_to_user_fk;
       public            postgres    false    213            �           1259    344327 +   fki_useroperationclaim_to_operationclaim_fk    INDEX     y   CREATE INDEX fki_useroperationclaim_to_operationclaim_fk ON public.tbluseroperationclaim USING btree (operationclaimid);
 ?   DROP INDEX public.fki_useroperationclaim_to_operationclaim_fk;
       public            postgres    false    215            �           1259    344321    fki_y    INDEX     I   CREATE INDEX fki_y ON public.tbluseroperationclaim USING btree (userid);
    DROP INDEX public.fki_y;
       public            postgres    false    215            �           2606    337149     tblaccount account_to_product_fk    FK CONSTRAINT     �   ALTER TABLE ONLY public.tblaccount
    ADD CONSTRAINT account_to_product_fk FOREIGN KEY (productid) REFERENCES public.tblproduct(id) NOT VALID;
 J   ALTER TABLE ONLY public.tblaccount DROP CONSTRAINT account_to_product_fk;
       public          postgres    false    3204    213    209            �           2606    337143    tblaccount account_to_user_fk    FK CONSTRAINT     �   ALTER TABLE ONLY public.tblaccount
    ADD CONSTRAINT account_to_user_fk FOREIGN KEY (userid) REFERENCES public.tbluser(id) NOT VALID;
 G   ALTER TABLE ONLY public.tblaccount DROP CONSTRAINT account_to_user_fk;
       public          postgres    false    3206    214    209            �           2606    337161    tbloffer offet_to_product_fk    FK CONSTRAINT     �   ALTER TABLE ONLY public.tbloffer
    ADD CONSTRAINT offet_to_product_fk FOREIGN KEY (productid) REFERENCES public.tblproduct(id) NOT VALID;
 F   ALTER TABLE ONLY public.tbloffer DROP CONSTRAINT offet_to_product_fk;
       public          postgres    false    213    211    3204            �           2606    337155    tbloffer offet_to_user_fk    FK CONSTRAINT     �   ALTER TABLE ONLY public.tbloffer
    ADD CONSTRAINT offet_to_user_fk FOREIGN KEY (userid) REFERENCES public.tbluser(id) NOT VALID;
 C   ALTER TABLE ONLY public.tbloffer DROP CONSTRAINT offet_to_user_fk;
       public          postgres    false    3206    211    214            �           2606    337137 !   tblproduct product_to_category_fk    FK CONSTRAINT     �   ALTER TABLE ONLY public.tblproduct
    ADD CONSTRAINT product_to_category_fk FOREIGN KEY (categoryid) REFERENCES public.tblcategory(id) NOT VALID;
 K   ALTER TABLE ONLY public.tblproduct DROP CONSTRAINT product_to_category_fk;
       public          postgres    false    210    3193    213            �           2606    344459    tblproduct product_to_offer_fk    FK CONSTRAINT     �   ALTER TABLE ONLY public.tblproduct
    ADD CONSTRAINT product_to_offer_fk FOREIGN KEY (offerid) REFERENCES public.tbloffer(id) NOT VALID;
 H   ALTER TABLE ONLY public.tblproduct DROP CONSTRAINT product_to_offer_fk;
       public          postgres    false    211    3197    213            �           2606    337167    tblproduct product_to_user_fk    FK CONSTRAINT     �   ALTER TABLE ONLY public.tblproduct
    ADD CONSTRAINT product_to_user_fk FOREIGN KEY (userid) REFERENCES public.tbluser(id) NOT VALID;
 G   ALTER TABLE ONLY public.tblproduct DROP CONSTRAINT product_to_user_fk;
       public          postgres    false    3206    214    213            �           2606    344322 =   tbluseroperationclaim useroperationclaim_to_operationclaim_fk    FK CONSTRAINT     �   ALTER TABLE ONLY public.tbluseroperationclaim
    ADD CONSTRAINT useroperationclaim_to_operationclaim_fk FOREIGN KEY (operationclaimid) REFERENCES public.tbloperationclaim(id) NOT VALID;
 g   ALTER TABLE ONLY public.tbluseroperationclaim DROP CONSTRAINT useroperationclaim_to_operationclaim_fk;
       public          postgres    false    212    3199    215            �           2606    344316 3   tbluseroperationclaim useroperationclaim_to_user_fk    FK CONSTRAINT     �   ALTER TABLE ONLY public.tbluseroperationclaim
    ADD CONSTRAINT useroperationclaim_to_user_fk FOREIGN KEY (userid) REFERENCES public.tbluser(id) NOT VALID;
 ]   ALTER TABLE ONLY public.tbluseroperationclaim DROP CONSTRAINT useroperationclaim_to_user_fk;
       public          postgres    false    215    3206    214           