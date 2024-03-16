using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;



namespace LifePrint.api
{
    // URL Format 
    [Route("api/[controller]/[action]")]
    [ApiController]

    public class landbotdataapi : ControllerBase
    {
        // Health Entry API
        public HttpResponseMessage Health(int h1_gh_score, int h2_gh_score, int h3_gh_score,
            int h4_gh_score, int h5_gh_score, int h6_ef_score, int h7_ew_score,
            int h8_ew_score, int h9_ew_score, int h10_ef_score, int h11_ew_score,
            int h12_ef_score, int h13_ew_score, int h14_ef_score, int h15_gh_score,
            int h16_gh_score, int h17_gh_score, int h18_gh_score, string email , int userID)
        { 


            // Create DB Context instance 
            var db = new LifeprintDatabaseContext();

            // Get existing users where the email matches parameter 
            var existingUsers = db.Users.Where(u => u.UserEmail == email);


            // Check if user exists already
            if (!(existingUsers.Count() > 0))
            {
                Users newUser = new Users();
                newUser.UserEmail = email;
                newUser.UserLearnWorldsId = 1;
                newUser.UserPassword = "";
    
                db.Users.Add(newUser);
                db.SaveChanges();
            }

            // Process Data




            // Calculate Totals ----------------------------------------------------------
            int? h_tot_score =  h1_gh_score + h2_gh_score + h3_gh_score + h4_gh_score + h5_gh_score +
                h6_ef_score + h7_ew_score + h8_ew_score + h9_ew_score + h10_ef_score + h11_ew_score + h12_ef_score +
                h13_ew_score + h14_ef_score + h15_gh_score + h16_gh_score + h17_gh_score + h18_gh_score;


            int? h_gh_tot_score = h1_gh_score + h2_gh_score + h3_gh_score + h4_gh_score + h5_gh_score + h15_gh_score +
                h16_gh_score + h17_gh_score + h18_gh_score;


            int? h_ef_tot_score = h6_ef_score + h10_ef_score + h12_ef_score + h14_ef_score;

            int? h_ew_tot_score = h7_ew_score + h8_ew_score + h9_ew_score + h11_ew_score + h13_ew_score;

            // Calculate quotient ---------------------------------------------------------

            float? h_pc1_score = (float)h_gh_tot_score / 108;
            float? h_gh_pc1_score = (float)h_gh_tot_score / 45;
            float? h_ef_pc1_score = (float)h_ef_tot_score / 24;
            float? h_ew_pc1_score = (float)h_ew_tot_score / 30;

            // Calculate Percent Scores
            float? h_percent_score = h_pc1_score * 100;
            float? h_gh_percent_score = h_gh_pc1_score * 100;
            float? h_ef_percent_score = h_ef_pc1_score * 100;
            float? h_ew_percent_score = h_ew_pc1_score * 100;

            // Calculate Overall Percentages -------------------------------------------------

            float? h_percent_2dp_score = ((int)(h_percent_score * 100)) / 100;
            float? h_gh_percent_2dp_score = ((int)(h_gh_percent_score * 100)) / 100;
            float? h_ef_percent_2dp_score = ((int)(h_ef_percent_score * 100)) / 100;
            float? h_ew_percent_2dp_score = ((int)(h_ew_percent_score * 100)) / 100;


            // Create new entry with answers from landbot

            Health newHealthEntry = new Health();
            newHealthEntry.H1GhHvsfScore = h1_gh_score;
            newHealthEntry.H2GhScore = h2_gh_score;
            newHealthEntry.H3GhScore = h3_gh_score;
            newHealthEntry.H4GhScore = h4_gh_score;
            newHealthEntry.H5GhScore = h5_gh_score;
            newHealthEntry.H6EfScore = h6_ef_score;
            newHealthEntry.H7EwScore = h7_ew_score;
            newHealthEntry.H8EwScore = h8_ew_score;
            newHealthEntry.H9EwScore = h9_ew_score;
            newHealthEntry.H10EfScore = h10_ef_score;
            newHealthEntry.H11EwScore = h11_ew_score;
            newHealthEntry.H12EfScore = h12_ef_score;
            newHealthEntry.H13EwScore = h13_ew_score;
            newHealthEntry.H14EfScore = h14_ef_score;
            newHealthEntry.H15GhScore = h15_gh_score;
            newHealthEntry.H16GhScore = h16_gh_score;
            newHealthEntry.H17GhScore = h17_gh_score;
            newHealthEntry.H18GhScore = h18_gh_score;
            newHealthEntry.HGhTotScore = h_gh_tot_score;
            newHealthEntry.HHvsfTotScore = null;
            newHealthEntry.HEfTotScore = h_ef_tot_score;
            newHealthEntry.HEwTotScore = h_ew_tot_score;
            newHealthEntry.HPercent2dpScore = Convert.ToDouble(h_percent_2dp_score);
            newHealthEntry.HGhPercent2dpScore = Convert.ToDouble(h_gh_percent_2dp_score);
            newHealthEntry.HHvsfPercent2dpScore = null;
            newHealthEntry.HEfPercent2dpScore = Convert.ToDouble(h_ef_percent_2dp_score);
            newHealthEntry.HEwPercent2dpScore = Convert.ToDouble(h_ew_percent_2dp_score);

            // Add health entry to database
            db.Health.Add(newHealthEntry);
            db.SaveChanges();

            // Get id of inserted item
            int healthID = newHealthEntry.HealthId;

            // Check for incomplete result to add health id 
            var incompleteEntry = db.Results
                .Where(order => order.Health == null && order.UserEmail == email)
                .Select(s => new { s.ResultId }).ToList();


            // Update result record with health id
            if (incompleteEntry.Count > 0)
            {
                int incompleteEntryId = incompleteEntry[0].ResultId;

                Results updatedResult = (from x in db.Results
                                         where x.ResultId == incompleteEntryId
                                         select x).First();
                updatedResult.HealthId = healthID;

                
                db.SaveChanges();

            }
            else
            {
                Results newResultEntry = new Results();
                newResultEntry.ResultDate = DateTime.Today;
                newResultEntry.UserEmail = email;
                newResultEntry.HealthId = healthID;

                db.Results.Add(newResultEntry);
                db.SaveChanges();
            }


            return new HttpResponseMessage(HttpStatusCode.Accepted);
        }

        public HttpResponseMessage Being(int b1_sl_score, int b2_sl_score, int b3_sl_score,
            int b4_eafe_score, int b5_asd_score, int b6_tr_score, int b7_eafe_score, int b8_asd_score, int b9_sase_score, int b10_ir_score, int b11_sase_score, int b12_asd_score,
            int b13_asd_score, int b14_asd_score, int b15_ir_score, int b16_tr_score, int b17_sase_score, int b18_tr_score, int b19_pc_score, int b20_sa_score,
            int b21_pc_score, int b22_sa_score, int b23_pc_score, int b24_sa_score, int b25_pc_score, int b26_sa_score, int b27_pc_score, int b28_sa_score,
            string email)
        {
            using var db = new LifeprintDatabaseContext();

            Being newBeingEntry = new Being();
            newBeingEntry.B1SlScore = b1_sl_score;
            newBeingEntry.B2SlScore = b2_sl_score;
            newBeingEntry.B3SlScore = b3_sl_score;
            newBeingEntry.B4EafeScore = b4_eafe_score;
            newBeingEntry.B5AsdScore = b5_asd_score;
            newBeingEntry.B6TrScore = b6_tr_score;
            newBeingEntry.B7EafeScore = b7_eafe_score;
            newBeingEntry.B8AsdScore = b8_asd_score;
            newBeingEntry.B9SaseScore = b9_sase_score;
            newBeingEntry.B10IrScore = b10_ir_score;
            newBeingEntry.B11SaseScore = b11_sase_score;
            newBeingEntry.B12AsdScore = b12_asd_score;
            newBeingEntry.B13AsdScore = b13_asd_score;
            newBeingEntry.B14AsdScore = b14_asd_score;
            newBeingEntry.B15IrScore = b15_ir_score;
            newBeingEntry.B16TrScore = b16_tr_score;
            newBeingEntry.B17SaseScore = b17_sase_score;
            newBeingEntry.B18TrScore = b18_tr_score;
            newBeingEntry.B19PcScore = b19_pc_score;
            newBeingEntry.B20SaScore = b20_sa_score;
            newBeingEntry.B21PcScore = b21_pc_score;
            newBeingEntry.B22SaScore = b22_sa_score;
            newBeingEntry.B23PcScore = b23_pc_score;
            newBeingEntry.B24SaScore = b24_sa_score;
            newBeingEntry.B25PcScore = b25_pc_score;
            newBeingEntry.B26SaScore = b26_sa_score;
            newBeingEntry.B27PcScore = b27_pc_score;
            newBeingEntry.B28SaScore = b28_sa_score;


            db.Being.Add(newBeingEntry);
            db.SaveChanges();

            int beingId = newBeingEntry.BeingId;

            var incompleteEntry = db.Results
                .Where(order => order.Being == null && order.UserEmail == email)
                .Select(s => new { s.ResultId }).ToList();


            if (incompleteEntry.Count > 0)
            {

                int incompleteEntryId = incompleteEntry[0].ResultId;

                Results updatedResult = (from x in db.Results
                                         where x.ResultId == incompleteEntryId
                                         select x).First();
                updatedResult.BeingId = beingId;
                db.SaveChanges();
            }
            else
            {
                return new HttpResponseMessage(HttpStatusCode.ExpectationFailed);
            }


            return new HttpResponseMessage(HttpStatusCode.Accepted);
        }

        public HttpResponseMessage Social(int s2_hvsf_score, int s3_fm_score, int s4_fm_score, int s5_fr_score, int s6_fr_score,
            int s7_fr_score, int s8_r_score, int s9_n_score, int s10_n_score, int s11_c_score, int s12_e_score, int s13_fm_score, int s14_fm_score,
            int s15_fr_score, int s16_p_score, int s17_r_score, int s18_e_score, int s19_n_score, int s20_c_score, string email)
        {

            using var db = new LifeprintDatabaseContext();

            Social newSocialEntry = new Social();
            newSocialEntry.S2HvsfScore = s2_hvsf_score;
            newSocialEntry.S3FmScore = s3_fm_score;
            newSocialEntry.S4FmScore = s4_fm_score;
            newSocialEntry.S5FrScore = s5_fr_score;
            newSocialEntry.S6FrScore = s6_fr_score;
            newSocialEntry.S7PScore = s7_fr_score;
            newSocialEntry.S8RScore = s8_r_score;
            newSocialEntry.S9NScore = s9_n_score;
            newSocialEntry.S10NScore = s10_n_score;
            newSocialEntry.S11CScore = s11_c_score;
            newSocialEntry.S12EScore = s12_e_score;
            newSocialEntry.S13FmScore = s13_fm_score;
            newSocialEntry.S14FmScore = s14_fm_score;
            newSocialEntry.S15FrScore = s15_fr_score;
            newSocialEntry.S16PScore = s16_p_score;
            newSocialEntry.S17RScore = s17_r_score;
            newSocialEntry.S18EScore = s18_e_score;
            newSocialEntry.S19NScore = s19_n_score;
            newSocialEntry.S20CScore = s20_c_score;

            db.Social.Add(newSocialEntry);
            db.SaveChanges();

            int socialId = newSocialEntry.SocialId;

            var incompleteEntry = db.Results
                .Where(order => order.Social == null && order.UserEmail == email)
                .Select(s => new { s.ResultId }).ToList();


            if (incompleteEntry.Count > 0)
            {

                int incompleteEntryId = incompleteEntry[0].ResultId;

                Results updatedResult = (from x in db.Results
                                         where x.ResultId == incompleteEntryId
                                         select x).First();
                updatedResult.SocialId = socialId;

                int? healthId = db.Results.Where(r => r.ResultId == incompleteEntryId)
                    .Select(e => e.HealthId).ToList()[0];

                Health updatedHealth = (from x in db.Health
                                        where x.HealthId == healthId
                                        select x).First();

                int h_hvsf_tot_score = s2_hvsf_score;
                float? h_hvsf_pc1_score = (float)h_hvsf_tot_score / 6;
                float? h_hvsf_percent_score = h_hvsf_pc1_score * 100;
                float? h_hvsf_percent_2dp_score = (h_hvsf_percent_score / 100) * 100;

                updatedHealth.HHvsfTotScore = h_hvsf_tot_score;
                updatedHealth.HHvsfPercent2dpScore = h_hvsf_percent_2dp_score;


                db.SaveChanges();


            }
            else
            {
                Results newResultEntry = new Results();
                newResultEntry.ResultDate = DateTime.Today;
                newResultEntry.UserEmail = email;
                newResultEntry.SocialId = socialId;

                db.Results.Add(newResultEntry);
                db.SaveChanges();
            }


            return new HttpResponseMessage(HttpStatusCode.Accepted);
        }

        public HttpResponseMessage Vocation(int v1_p_pfbexh_score, int v2_fl_csb_res_score, int v3_d_mp_score, int v4_fl_aam_score, int v5_i_fl_trot_score, int v6_p_pfbexh_score, int v7_d_score,
            int v8_i_fl_cotah_score, int v9_d_im_score, int v10_p_im_pfbcyn_score, int v11_i_im_score, int v12_fl_cg__score, int v13_d_pfbcyn_score,
            int v14_i_score, int v15_fl_soc_score, int v16_p_im__score, int v17_d_fl_aam_score, int v18_fl_uf_pfbeff_score, int v19_i_score, int v20_p_res_score, int v21_fl_ae_pfbeff_score,
            int v22_i_res_score, int v23_p_res_score, int v24_va_fl_ae_score, int v25_va_fl_ae_score, int v26_va_fl_cg_score, int v27_va_paful_pfbeff_score, int v28_va_pacap_score, int v29_va_oaful_score, int v30_va_oatrt_em_pfbeff_score,
            int v31_va_oatrt_em_pfbeff_score, int v32_va_oacap_rsc_em_pfbrsc_score, int v33_va_oacap_rsc_em_pfbrsc_score, int v34_va_patrt_em_pfbcyn_score, int v35_va_oacap_dmd_pfbdmd_score, string email)
        {

            using var db = new LifeprintDatabaseContext();

            Vocation newVocationEntry = new Vocation();

            newVocationEntry.V1PPfbexhScore = v1_p_pfbexh_score;
            newVocationEntry.V2FlCsbResScore = v2_fl_csb_res_score;
            newVocationEntry.V3DMpScore = v3_d_mp_score;
            newVocationEntry.V4FlAamScore = v4_fl_aam_score;
            newVocationEntry.V5IFlTrotScore = v5_i_fl_trot_score;
            newVocationEntry.V6PPfbexhScore = v6_p_pfbexh_score;
            newVocationEntry.V7DScore = v7_d_score;
            newVocationEntry.V8IFlCotahScore = v8_i_fl_cotah_score;
            newVocationEntry.V9DImScore = v9_d_im_score;
            newVocationEntry.V10PImPfbcynScore = v10_p_im_pfbcyn_score;
            newVocationEntry.V11IImScore = v11_i_im_score;
            newVocationEntry.V12FlCgscore = v12_fl_cg__score;
            newVocationEntry.V13DPfbcynScore = v13_d_pfbcyn_score;
            newVocationEntry.V14IScore = v14_i_score;
            newVocationEntry.V15FlSocScore = v15_fl_soc_score;
            newVocationEntry.V16PImscore = v16_p_im__score;
            newVocationEntry.V17DFlAamScore = v17_d_fl_aam_score;
            newVocationEntry.V18FlUfPfbeffScore = v18_fl_uf_pfbeff_score;
            newVocationEntry.V19IScore = v19_i_score;
            newVocationEntry.V20PResScore = v20_p_res_score;
            newVocationEntry.V21FlAePfbeffScore = v21_fl_ae_pfbeff_score;
            newVocationEntry.V22IResScore = v22_i_res_score;
            newVocationEntry.V23PResScore = v23_p_res_score;
            newVocationEntry.V24VaFlAeScore = v24_va_fl_ae_score;
            newVocationEntry.V25VaFlAeScore = v25_va_fl_ae_score;
            newVocationEntry.V26VaFlCgScore = v26_va_fl_cg_score;
            newVocationEntry.V27VaPafulPfbeffScore = v27_va_paful_pfbeff_score;
            newVocationEntry.V28VaPacapScore = v28_va_pacap_score;
            newVocationEntry.V29VaOafulScore = v29_va_oaful_score;
            newVocationEntry.V30VaOatrtEmPfbeffScore = v30_va_oatrt_em_pfbeff_score;
            newVocationEntry.V31VaPatrtEmScore = v31_va_oatrt_em_pfbeff_score;
            newVocationEntry.V32VaOacapRscEmPfbrscScore = v32_va_oacap_rsc_em_pfbrsc_score;
            newVocationEntry.V33VaOatrtPfbcynScore = v33_va_oacap_rsc_em_pfbrsc_score;
            newVocationEntry.V34VaPatrtEmPfbcynScore = v34_va_patrt_em_pfbcyn_score;
            newVocationEntry.V35VaOacapDmdPfbdmdScore = v35_va_oacap_dmd_pfbdmd_score;

            db.Vocation.Add(newVocationEntry);
            db.SaveChanges();

            int vocationID = newVocationEntry.VocationId;

            var incompleteEntry = db.Results
                .Where(order => order.Vocation == null && order.UserEmail == email)
                .Select(s => new { s.ResultId }).ToList();


            if (incompleteEntry.Count > 0)
            {

                int incompleteEntryId = incompleteEntry[0].ResultId;

                Results updatedResult = (from x in db.Results
                                         where x.ResultId == incompleteEntryId
                                         select x).First();
                updatedResult.VocationId = vocationID;
                db.SaveChanges();
            }



            return new HttpResponseMessage(HttpStatusCode.Accepted);
        }

        public HttpResponseMessage Wealth(int w1_ws_score, int w2_ws_score, int w3_ws_score, int w4_ws_score, int w5_cwl_score,
            int w6_cwl_score, int w7_cwl_score, int w8_fwo_score, int w9_fwo_score, int w10_fwo_score, string email)
        {

            using var db = new LifeprintDatabaseContext();

            Wealth newWealthEntry = new Wealth();
            newWealthEntry.W1WsCwpScore = w1_ws_score;
            newWealthEntry.W2WsCwpScore = w2_ws_score;
            newWealthEntry.W3WsCwpScore = w3_ws_score;
            newWealthEntry.W4WsCwpScore = w4_ws_score;
            newWealthEntry.W5CwlScore = w5_cwl_score;
            newWealthEntry.W6CwlScore = w6_cwl_score;
            newWealthEntry.W7CwlScore = w7_cwl_score;
            newWealthEntry.W8FwoCwpScore = w8_fwo_score;
            newWealthEntry.W9FwoCwpScore = w9_fwo_score;
            newWealthEntry.W10FwoCwpScore = w10_fwo_score;



            db.Wealth.Add(newWealthEntry);
            db.SaveChanges();

            int wealthId = newWealthEntry.WealthId;

            var incompleteEntry = db.Results
                .Where(order => order.Wealth == null && order.UserEmail == email)
                .Select(s => new { s.ResultId }).ToList();


            if (incompleteEntry.Count > 0)
            {

                int incompleteEntryId = incompleteEntry[0].ResultId;

                Results updatedResult = (from x in db.Results
                                         where x.ResultId == incompleteEntryId
                                         select x).First();
                updatedResult.WealthId = wealthId;
                db.SaveChanges();
            }
            else
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }


            return new HttpResponseMessage(HttpStatusCode.Accepted);
        }



    }
}
