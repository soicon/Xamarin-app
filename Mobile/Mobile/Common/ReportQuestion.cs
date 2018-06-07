using System;
using System.Collections.Generic;
using System.Text;
using Mobile.Models.ReportBO;

namespace Mobile.Common
{
    public class ReportQuestion
    {
        public static List<ReportBO> initReport()
        {
            List<Answer> ListAnswer = new List<Answer>();
            List<Question> ListQuestion = new List<Question>();
            List<ReportBO> ListReport = new List<ReportBO>();
            Question question = new Question();
            #region Thông tin chung
            ReportBO reportBO = new ReportBO();
            reportBO.Title = "Thông tin chung";
            ListQuestion = new List<Question>();
            #region Câu 1
            question = new Question();
            question.QuestionNumber = 1;
            question.Title = "Tổng số thôn trong xã";
            ListAnswer = new List<Answer>();
            ListAnswer.Add(new Answer("", "", false));
            question.ListAnswer = ListAnswer;
            ListQuestion.Add(question);
            #endregion
            //#region Câu 2
            //question = new Question();
            //question.QuestionNumber = 1;
            //question.Title = "Tổng số thôn trong xã";
            //ListAnswer = new List<Answer>();
            //ListAnswer.Add(new Answer("", "", false));
            //ListQuestion.Add(question);
            //#endregion
            #region Câu 2
            question = new Question();
            question.QuestionNumber = 2;
            question.Title = "Tổng số hộ trong xã";
            ListAnswer = new List<Answer>();
            ListAnswer.Add(new Answer("", "", false));
            question.ListAnswer = ListAnswer;
            ListQuestion.Add(question);
            #endregion

            #region Câu 3
            question = new Question();
            question.QuestionNumber = 3;
            question.Title = " Tổng số dân";
            ListAnswer = new List<Answer>();
            ListAnswer.Add(new Answer("", "", false));
            question.ListAnswer = ListAnswer;
            ListQuestion.Add(question);
            #endregion

            #region Câu 4
            question = new Question();
            question.QuestionNumber = 4;
            question.Title = "Trong đó tổng số nữ";
            ListAnswer = new List<Answer>();
            ListAnswer.Add(new Answer("", "", false));
            question.ListAnswer = ListAnswer;
            ListQuestion.Add(question);
            #endregion

            question = new Question();
            question.QuestionNumber = 5;
            question.Title = "Tổng số hộ nghèo";
            ListAnswer = new List<Answer>();
            ListAnswer.Add(new Answer("", "", false));
            question.ListAnswer = ListAnswer;
            ListQuestion.Add(question);

            question = new Question();
            question.QuestionNumber = 6;
            question.Title = "Tổng số hộ cận nghèo";
            ListAnswer = new List<Answer>();
            ListAnswer.Add(new Answer("", "", false));
            question.ListAnswer = ListAnswer;
            ListQuestion.Add(question);

            question = new Question();
            question.QuestionNumber = 7;
            question.Title = "Tổng số thôn bị thiệt hại";
            ListAnswer = new List<Answer>();
            ListAnswer.Add(new Answer("", "", false));
            question.ListAnswer = ListAnswer;
            ListQuestion.Add(question);

            question = new Question();
            question.QuestionNumber = 8;
            question.Title = "Tổng số hộ gia đình bị thiệt hại nói chung";
            ListAnswer = new List<Answer>();
            ListAnswer.Add(new Answer("", "", false));
            question.ListAnswer = ListAnswer;
            ListQuestion.Add(question);

            question = new Question();
            question.QuestionNumber = 9;
            question.Title = "Tổng số hộ nghèo bị thiệt hại";
            ListAnswer = new List<Answer>();
            ListAnswer.Add(new Answer("", "", false));
            question.ListAnswer = ListAnswer;
            ListQuestion.Add(question);

            question = new Question();
            question.QuestionNumber = 10;
            question.Title = "Tổng số hộ cận ngheo bị thiệt hại";
            ListAnswer = new List<Answer>();
            ListAnswer.Add(new Answer("", "", false));
            question.ListAnswer = ListAnswer;
            ListQuestion.Add(question);

            question = new Question();
            question.QuestionNumber = 11;
            question.Title = "Tổng số người chết do thảm họa";
            ListAnswer = new List<Answer>();
            ListAnswer.Add(new Answer("", "", false));
            question.ListAnswer = ListAnswer;
            ListQuestion.Add(question);
            #region Cau 12
            question = new Question();
            question.QuestionNumber = 12;
            question.Title = ".Tổng số người bị thương do thảm họa";
            ListAnswer = new List<Answer>();
            ListAnswer.Add(new Answer("", "", false));
            question.ListAnswer = ListAnswer;
            ListQuestion.Add(question);
            #endregion

            #region Câu 13
            question = new Question();
            question.QuestionNumber = 13;
            question.Title = "Trong số các hộ nghèo và cận nghèo bị thiệt hại bởi thảm họa nêu trên, có bao nhiêu hộ có các đối tượng sau:";
            ListAnswer = new List<Answer>();
            ListAnswer.Add(new Answer("a. Phụ nữ có thai hoặc cho con bú", "", false));
            ListAnswer.Add(new Answer("b. Trẻ em dưới 5 tuổi", "", false));
            ListAnswer.Add(new Answer("c.Nữ là lao động chính trong gia đình hộ (là người nuôi sống gia đình)", "", false));
            ListAnswer.Add(new Answer("d.Người khuyết tật và người có bệnh mãn tính", "", false));
            ListAnswer.Add(new Answer("e.Người già", "", false));
            ListAnswer.Add(new Answer("f.Người không có năng lực lao động", "", false));
            question.ListAnswer = ListAnswer;
            ListQuestion.Add(question);
            #endregion
            #region Câu 14
            question = new Question();
            question.QuestionNumber = 14;
            question.Title = "Đặc điểm văn hóa xã hội của địa phương:";
            ListAnswer = new List<Answer>();
            ListAnswer.Add(new Answer("1.Tỷ lệ % người dân tộc thiểu số", "", false));
            ListAnswer.Add(new Answer("2. Tỷ lệ % người biết đọc, biết viết", "", false));
            question.ListAnswer = ListAnswer;
            ListQuestion.Add(question);
            #endregion
            #region Câu 15
            question = new Question();
            question.QuestionNumber = 15;
            question.Title = "Các tình trạng dễ bị tổn thương (trước thảm họa) là gì?";
            ListAnswer = new List<Answer>();
            ListAnswer.Add(new Answer("", "", false));
            question.ListAnswer = ListAnswer;
            ListQuestion.Add(question);
            #endregion

            #region Câu 16
            question = new Question();
            question.QuestionNumber = 16;
            question.Title = "Các loại hình sinh kế chủ yếu ở địa phương (đánh dấu vào ô thích hợp):";
            ListAnswer = new List<Answer>();
            ListAnswer.Add(new Answer("a. Nông nghiệp (lúa, hoa màu)", "", true));
            ListAnswer.Add(new Answer("b. Lâm nghiệp", "", true));
            ListAnswer.Add(new Answer("c. Chăn nuôi gia súc, gia cầm", "", true));
            ListAnswer.Add(new Answer("d. Nuôi trồng thủy sản (bao gồm cả đánh bắt hải sản)", "", true));
            ListAnswer.Add(new Answer("e. Làm thuê", "", true));
            ListAnswer.Add(new Answer("f. Kinh doanh, buôn bán", "", true));
            ListAnswer.Add(new Answer("g. Khác (Nêu rõ)", "", false));
            question.ListAnswer = ListAnswer;
            ListQuestion.Add(question);
            #endregion
            #region Câu 17 đặc biệt hơn chút
            question = new Question();
            question.QuestionNumber = 17;
            question.Title = "17. Các hệ thống chức năng sau đây có vận hành không (dấu “v” vào các ô phù hợp)";
            ListAnswer = new List<Answer>();
            ListAnswer.Add(new Answer("a. Cơ sở y tế (bệnh viện, phòng khám, trạm y tế, trạm, điểm sơ cấp cứu)", "", true));
            ListAnswer.Add(new Answer("b. Phương tiện giao thông", "", true));
            ListAnswer.Add(new Answer("c. Đường xá (khả năng tiếp cận địa bàn bị ảnh hưởng)", "", true));
            ListAnswer.Add(new Answer("a. Cơ sở y tế (bệnh viện, phòng khám, trạm y tế, trạm, điểm sơ cấp cứu)", "", true));
            ListAnswer.Add(new Answer("b. Phương tiện giao thông", "", true));
            ListAnswer.Add(new Answer("c. Đường xá (khả năng tiếp cận địa bàn bị ảnh hưởng)", "", true));
            question.ListAnswer = ListAnswer;
            ListQuestion.Add(question);
            #endregion
            #region Câu 18
            question = new Question();
            question.QuestionNumber = 18;
            question.Title = "Các hoạt động ứng phó đã hoặc sẽ diễn ra tại địa phương?";
            ListAnswer = new List<Answer>();
            ListAnswer.Add(new Answer("1.Hoạt động là gì", "", false));
            ListAnswer.Add(new Answer("2. Do ai tiến hành", "", false));
            question.ListAnswer = ListAnswer;
            ListQuestion.Add(question);
            #endregion
            #region Câu 19
            question = new Question();
            question.QuestionNumber = 19;
            question.Title = "Tình hình an ninh của địa phương như thế nào, có gì đáng lo ngại không?";
            ListAnswer = new List<Answer>();
            ListAnswer.Add(new Answer("Không", "", true));
            ListAnswer.Add(new Answer("Có", "", true));
            question.ListAnswer = ListAnswer;
            ListQuestion.Add(question);
            #endregion
            #region Câu 20
            question = new Question();
            question.QuestionNumber = 20;
            question.Title = "bảng";
            ListAnswer = new List<Answer>();
            ListAnswer.Add(new Answer("Ghi thêm quan sát/phát hiện:", "", false));
            ListAnswer.Add(new Answer("Các thông tin cần kiểm chứng thêm:", "", false));
            ListAnswer.Add(new Answer("Ghi chú khác", "", false));
            question.ListAnswer = ListAnswer;
            ListQuestion.Add(question);
            #endregion

            reportBO.ListQuestion = ListQuestion;
            #endregion
            ListReport.Add(reportBO);
            #region Tình trạng sức khỏe
            reportBO = new ReportBO();
            reportBO.Title = "Tình trạng sức khỏe";
            ListQuestion = new List<Question>();
            #region Câu 21
            question = new Question();
            question.QuestionNumber = 21;
            question.Title = "Sau thảm họa, cộng đồng bị ảnh hưởng có bị tác động về sức khỏe không?";
            ListAnswer = new List<Answer>();
            ListAnswer.Add(new Answer("Không (Nếu không ,tiếp câu 22)", "", true));
            ListAnswer.Add(new Answer("Có (Nếu có trả lời các câu)", "", true));
            ListAnswer.Add(new Answer("Nêu cụ thể ảnh hưởng gì và số ca mắc cao hơn bình thường là bao nhiêu?", "", false));
            ListAnswer.Add(new Answer("Các can thiệp nào đã hoặc sẽ thực hiện?", "", false));
            ListAnswer.Add(new Answer("Đối tượng nào được hỗ trợ?", "", false));
            ListAnswer.Add(new Answer("Do ai thực hiện?", "", false));
            question.ListAnswer = ListAnswer;
            ListQuestion.Add(question);
            #endregion
            #region Câu 22
            question = new Question();
            question.QuestionNumber = 22;
            question.Title = "Có bệnh truyền nhiễm nào phát sinh do hậu quả của thảm họa hay không?";
            ListAnswer = new List<Answer>();
            ListAnswer.Add(new Answer("Không (Nếu không ,tiếp câu 23)", "", true));
            ListAnswer.Add(new Answer("Có (Nếu có trả lời tiếp câu 22c)", "", true));
            ListAnswer.Add(new Answer("Nêu cụ thể bệnh gì?", "", false));
            ListAnswer.Add(new Answer("Các can thiệp nào đã hoặc sẽ thực hiện?", "", false));
            ListAnswer.Add(new Answer("Do ai thực hiện?", "", false));
            question.ListAnswer = ListAnswer;
            ListQuestion.Add(question);
            #endregion
            #region Câu 23
            question = new Question();
            question.QuestionNumber = 23;
            question.Title = "Người dân có phải trả tiền thuốc/viện phí không?";
            ListAnswer = new List<Answer>();
            ListAnswer.Add(new Answer("Có", "", true));
            ListAnswer.Add(new Answer("Không", "", true));
            ListAnswer.Add(new Answer("Nếu có, ghi thêm thông tin", "", false));
            question.ListAnswer = ListAnswer;
            ListQuestion.Add(question);
            #endregion
            #region Câu 24
            question = new Question();
            question.QuestionNumber = 24;
            question.Title = "bảng";
            ListAnswer = new List<Answer>();
            ListAnswer.Add(new Answer("Ghi thêm quan sát/phát hiện:", "", false));
            ListAnswer.Add(new Answer("Các thông tin cần kiểm chứng thêm:", "", false));
            ListAnswer.Add(new Answer("Ghi chú khác", "", false));
            question.ListAnswer = ListAnswer;
            ListQuestion.Add(question);
            #endregion
            reportBO.ListQuestion = ListQuestion;
            #endregion
            ListReport.Add(reportBO);
            #region Nước sạch và vệ sinh
            reportBO = new ReportBO();
            reportBO.Title = "Nước sạch và vệ sinh";
            ListQuestion = new List<Question>();
            #region Câu 25
            question = new Question();
            question.QuestionNumber = 25;
            question.Title = "Sau thảm họa, người dân hiện có đủ nước sạch (ăn uống, sinh hoạt) không?";
            ListAnswer = new List<Answer>();
            ListAnswer.Add(new Answer("Không", "", true));
            ListAnswer.Add(new Answer("Có", "", true));
            question.ListAnswer = ListAnswer;
            ListQuestion.Add(question);
            #endregion
            #region Câu 26
            question = new Question();
            question.QuestionNumber = 26;
            question.Title = "Hiện nay, mỗi người dân sử dụng bao nhiêu lít nước/ngày?";
            ListAnswer = new List<Answer>();
            ListAnswer.Add(new Answer("", "", false));
            question.ListAnswer = ListAnswer;
            ListQuestion.Add(question);
            #endregion
            #region Câu 27
            question = new Question();
            question.QuestionNumber = 27;
            question.Title = "Hiện tại, nước sinh hoạt của người dân lấy từ đâu?(đánh dấu “v” vào các ô phù hợp)";
            ListAnswer = new List<Answer>();
            ListAnswer.Add(new Answer("a. Giếng có nắp che, giếng khoan", "", true));
            ListAnswer.Add(new Answer("b. Nước mưa", "", true));
            ListAnswer.Add(new Answer("c. Nước ở sông, hồ, ao, đập", "", true));
            ListAnswer.Add(new Answer("d. Nước máy", "", true));
            ListAnswer.Add(new Answer("e. Khác (nêu rõ)", "", true));
            question.ListAnswer = ListAnswer;
            ListQuestion.Add(question);
            #endregion
            #region Câu 28
            question = new Question();
            question.QuestionNumber = 28;
            question.Title = "Nguồn nước này có nguy cơ bị nhiễm vi sinh vật hoặc hóa chất không?";
            ListAnswer = new List<Answer>();
            ListAnswer.Add(new Answer("Có", "", false));
            ListAnswer.Add(new Answer("Không", "", false));
            ListAnswer.Add(new Answer("Không biết", "", false));
            ListAnswer.Add(new Answer("Nếu có, ghi rõ nguy cơ", "", false));
            question.ListAnswer = ListAnswer;
            ListQuestion.Add(question);
            #endregion
            #region Câu 29
            question = new Question();
            question.QuestionNumber = 29;
            question.Title = "Có thể sử dụng nguồn nước nào để đủ cung cấp cho người bị ảnh hưởng?";
            ListAnswer = new List<Answer>();
            ListAnswer.Add(new Answer(" Nêu rõ nguồn nước", "", false));
            ListAnswer.Add(new Answer("Nêu rõ biện pháp cần thiết để xử lý nguồn nước", "", false));
            question.ListAnswer = ListAnswer;
            ListQuestion.Add(question);
            #endregion
            #region Câu 30
            question = new Question();
            question.QuestionNumber = 30;
            question.Title = "Người dân có dụng cụ chứa nước an toàn không?";
            ListAnswer = new List<Answer>();
            ListAnswer.Add(new Answer("Có", "", true));
            ListAnswer.Add(new Answer("Không", "", true));
            question.ListAnswer = ListAnswer;
            ListQuestion.Add(question);
            #endregion
            #region Câu 31
            question = new Question();
            question.QuestionNumber = 31;
            question.Title = "Hiện tại, người dân phải đi bao xa (tính theo mét) để lấy nước?";
            ListAnswer = new List<Answer>();
            ListAnswer.Add(new Answer("", "", false));
            question.ListAnswer = ListAnswer;
            ListQuestion.Add(question);
            #endregion
            #region Câu 32
            question = new Question();
            question.QuestionNumber = 32;
            question.Title = "Người dân có phải trả tiền mua nước sạch để dùng trong sinh hoạt không?";
            ListAnswer = new List<Answer>();
            ListAnswer.Add(new Answer("Có", "", true));
            ListAnswer.Add(new Answer("Không", "", true));
            question.ListAnswer = ListAnswer;
            ListQuestion.Add(question);
            #endregion
            #region Câu 33
            question = new Question();
            question.QuestionNumber = 33;
            question.Title = "Đã hoặc sẽ có hỗ trợ nào về nước sạch chưa?";
            ListAnswer = new List<Answer>();
            ListAnswer.Add(new Answer("Chưa", "", true));
            ListAnswer.Add(new Answer("Có (Nếu có, ghi rõ)", "", true));
            ListAnswer.Add(new Answer("Hỗ trợ gì/Đối tượng được hỗ trợ", "", false));
            ListAnswer.Add(new Answer("Đơn vị hỗ trợ", "", false));
            question.ListAnswer = ListAnswer;
            ListQuestion.Add(question);
            #endregion
            #region Câu 34
            question = new Question();
            question.QuestionNumber = 34;
            question.Title = "Sau thảm họa, người dân đại tiện ở đâu? (đánh dấu “v” vào các ô phù hợp)";
            ListAnswer = new List<Answer>();
            ListAnswer.Add(new Answer("Hố xí 2 ngăn/nhà cầu của hộ gia đình", "", true));
            ListAnswer.Add(new Answer("Nhà vệ sinh/nhà cầu tập thẻ của thôn/ấp", "", true));
            ListAnswer.Add(new Answer("Hố xí tự hoại/nhà cầu của hộ gia đình", "", true));
            ListAnswer.Add(new Answer("Ao cá, sông suối", "", true));
            ListAnswer.Add(new Answer("Ruộng, vườn/bụi cây", "", true));
            ListAnswer.Add(new Answer("Khác (Nêu rõ)", "", true));
            question.ListAnswer = ListAnswer;
            ListQuestion.Add(question);
            #endregion
            #region Câu 35
            question = new Question();
            question.QuestionNumber = 35;
            question.Title = "Người dân có nước sạch và xà phòng để rửa tay sau khi đi vệ sinh không?";
            ListAnswer = new List<Answer>();
            ListAnswer.Add(new Answer("Có", "", true));
            ListAnswer.Add(new Answer("Không", "", true));
            ListAnswer.Add(new Answer("Ý kiến khác", "", true));
            question.ListAnswer = ListAnswer;
            ListQuestion.Add(question);
            #endregion
            #region Câu 36
            question = new Question();
            question.QuestionNumber = 36;
            question.Title = "Loại nhà vệ sinh/nhà cầu thông dụng ở địa phương là gì?";
            ListAnswer = new List<Answer>();
            ListAnswer.Add(new Answer("", "", false));
            question.ListAnswer = ListAnswer;
            ListQuestion.Add(question);
            #endregion
            #region Câu 37
            question = new Question();
            question.QuestionNumber = 37;
            question.Title = "Loại vật liệu thông dụng để xây nhà vệ sinh/nhà cầu ở địa phương là gì?";
            ListAnswer = new List<Answer>();
            ListAnswer.Add(new Answer("", "", false));
            question.ListAnswer = ListAnswer;
            ListQuestion.Add(question);
            #endregion
            #region Câu 38
            question = new Question();
            question.QuestionNumber = 38;
            question.Title = "Đã hoặc sẽ có hỗ trợ nào về nhà vệ sinh/nhà cầu chưa?";
            ListAnswer = new List<Answer>();
            ListAnswer.Add(new Answer("Không", "", true));
            ListAnswer.Add(new Answer("Có (Nếu có, ghi rõ)", "", true));
            ListAnswer.Add(new Answer("Hỗ trợ gì/Đối tượng được hỗ trợ", "", false));
            ListAnswer.Add(new Answer("Đơn vị hỗ trợ", "", false));
            question.ListAnswer = ListAnswer;
            ListQuestion.Add(question);
            #endregion
            #region Câu 39
            question = new Question();
            question.QuestionNumber = 34;
            question.Title = "Các hộ dân xử lý rác thải như thế nào? (đánh dấu “v” vào các ô phù hợp)";
            ListAnswer = new List<Answer>();
            ListAnswer.Add(new Answer("Đốt", "", true));
            ListAnswer.Add(new Answer("Chôn", "", true));
            ListAnswer.Add(new Answer("Thu rác tập trung", "", true));
            ListAnswer.Add(new Answer("Hình thức khác (ghi rõ)", "", true));
            question.ListAnswer = ListAnswer;
            ListQuestion.Add(question);
            #endregion
            #region Câu 40
            question = new Question();
            question.QuestionNumber = 40;
            question.Title = "bảng";
            ListAnswer = new List<Answer>();
            ListAnswer.Add(new Answer("Ghi thêm quan sát/phát hiện:", "", false));
            ListAnswer.Add(new Answer("Các thông tin cần kiểm chứng thêm:", "", false));
            ListAnswer.Add(new Answer("Ghi chú khác", "", false));
            question.ListAnswer = ListAnswer;
            ListQuestion.Add(question);
            #endregion

            reportBO.ListQuestion = ListQuestion;
            #endregion
            ListReport.Add(reportBO);


            #region Lương thực/dinh dưỡng
            reportBO = new ReportBO();
            reportBO.Title = "Lương thực/dinh dưỡng";
            ListQuestion = new List<Question>();
            #region Câu 41
            question = new Question();
            question.QuestionNumber = 41;
            question.Title = "Sau thảm họa, việc sản xuất lương thực của cộng đồng có bị ảnh hưởng gì không?";
            ListAnswer = new List<Answer>();
            ListAnswer.Add(new Answer("Không", "", true));
            ListAnswer.Add(new Answer("Có", "", true));
            ListAnswer.Add(new Answer("Nếu có, ghi rõ nguy cơ", "", false));
            question.ListAnswer = ListAnswer;
            ListQuestion.Add(question);
            #endregion
            #region Câu 42
            question = new Question();
            question.QuestionNumber = 42;
            question.Title = "Lương thực dự trữ của người dân có bị thiệt hại không?";
            ListAnswer = new List<Answer>();
            ListAnswer.Add(new Answer("Không", "", true));
            ListAnswer.Add(new Answer("Có", "", true));
            ListAnswer.Add(new Answer("Nếu có, ghi rõ nguy cơ", "", false));
            question.ListAnswer = ListAnswer;
            ListQuestion.Add(question);
            #endregion
            #region Câu 43
            question = new Question();
            question.QuestionNumber = 43;
            question.Title = "Người dân bị ảnh hưởng đã làm gì để ứng phó với thiệt hại này?";
            ListAnswer = new List<Answer>();
            ListAnswer.Add(new Answer("", "", false));
            question.ListAnswer = ListAnswer;
            ListQuestion.Add(question);
            #endregion
            #region Câu 44
            question = new Question();
            question.QuestionNumber = 44;
            question.Title = "Đã hoặc sẽ có can thiệp về lương thực chưa?";
            ListAnswer = new List<Answer>();
            ListAnswer.Add(new Answer("Không", "", true));
            ListAnswer.Add(new Answer("Có (Nếu có trả lời câu 44c)", "", true));
            ListAnswer.Add(new Answer("Nêu rõ các can thiệp?", "", false));
            ListAnswer.Add(new Answer("Do ai thực hiện?", "", false));
            question.ListAnswer = ListAnswer;
            ListQuestion.Add(question);
            #endregion
            #region Câu 45
            question = new Question();
            question.QuestionNumber = 45;
            question.Title = "Thu nhập của người dân bị ảnh hưởng có bị tác động gì không?";
            ListAnswer = new List<Answer>();
            ListAnswer.Add(new Answer("Không", "", true));
            ListAnswer.Add(new Answer("Có", "", true));
            ListAnswer.Add(new Answer("Nếu có, ghi rõ nguy cơ", "", false));
            question.ListAnswer = ListAnswer;
            ListQuestion.Add(question);
            #endregion
            #region Câu 46
            question = new Question();
            question.QuestionNumber = 46;
            question.Title = "Hiện tại, người dân có tiếp cận được chợ/cửa hàng bán lương thực hay không?";
            ListAnswer = new List<Answer>();
            ListAnswer.Add(new Answer("Không", "", true));
            ListAnswer.Add(new Answer("Có (nếu có, xác định loại chợ/cửa hàng người dân có thể mua lương thực)(đánh dấu “v” vào các ô phù hợp)", "", true));
            ListAnswer.Add(new Answer("Người bán lẻ số lượng ít", "", true));
            ListAnswer.Add(new Answer("Người bán lẻ số lượng lớn", "", true));
            ListAnswer.Add(new Answer("Người bán buôn", "", true));
            question.ListAnswer = ListAnswer;
            ListQuestion.Add(question);
            #endregion
            #region Câu 47
            question = new Question();
            question.QuestionNumber = 47;
            question.Title = "Trung bình, người dân đi mất bao lâu (tính bằng phút) để đến được chợ/cửa hàng?";
            ListAnswer = new List<Answer>();
            ListAnswer.Add(new Answer("", "", false));
            question.ListAnswer = ListAnswer;
            ListQuestion.Add(question);
            #endregion
            #region Câu 48
            question = new Question();
            question.QuestionNumber = 48;
            question.Title = "Sau bão, giá mặt hàng lương thực chính (gạo) có biến động không? (câu số 48 - 50 dùng để phỏng vấn người buôn bán ở địa bàn gần nhất)";
            ListAnswer = new List<Answer>();
            ListAnswer.Add(new Answer("Không", "", true));
            ListAnswer.Add(new Answer("Có", "", true));
            ListAnswer.Add(new Answer("Nếu có, ghi rõ", "", false));
            question.ListAnswer = ListAnswer;
            ListQuestion.Add(question);
            #endregion
            #region Câu 49
            question = new Question();
            question.QuestionNumber = 49;
            question.Title = "Hiện tại, gạo có sẵn trên thị trường địa phương không? (đánh dấu “v” vào ô phù hợp)";
            ListAnswer = new List<Answer>();
            ListAnswer.Add(new Answer("đủ hàng cho ít nhất 1 tuần", "", true));
            ListAnswer.Add(new Answer("đủ hàng cho ít hơn 1 tuần (từ 3-5 ngày)", "", true));
            ListAnswer.Add(new Answer("số lượng hạn chế chỉ đủ cho 1-2 ngày", "", true));
            ListAnswer.Add(new Answer("không có hàng dự trữ 0-1 ngày", "", true));
            question.ListAnswer = ListAnswer;
            ListQuestion.Add(question);
            #endregion
            #region Câu 50
            question = new Question();
            question.QuestionNumber = 50;
            question.Title = "Giả sử nhu cầu của khách hàng tăng gấp đôi, anh/chị có đủ hàng để bán không?";
            ListAnswer = new List<Answer>();
            ListAnswer.Add(new Answer("Có", "", true));
            ListAnswer.Add(new Answer("Không", "", true));
            question.ListAnswer = ListAnswer;
            ListQuestion.Add(question);
            #endregion
            #region Câu 51
            question = new Question();
            question.QuestionNumber = 51;
            question.Title = "Đã bao giờ anh/chị không có đủ hàng để bán chưa?";
            ListAnswer = new List<Answer>();
            ListAnswer.Add(new Answer("Có", "", true));
            ListAnswer.Add(new Answer("Không", "", true));
            ListAnswer.Add(new Answer("Nếu có ghi rõ", "", true));
            question.ListAnswer = ListAnswer;
            ListQuestion.Add(question);
            #endregion
            #region Câu 52
            question = new Question();
            question.QuestionNumber = 52;
            question.Title = "bảng";
            ListAnswer = new List<Answer>();
            ListAnswer.Add(new Answer("Ghi thêm quan sát/phát hiện:", "", false));
            ListAnswer.Add(new Answer("Các thông tin cần kiểm chứng thêm:", "", false));
            ListAnswer.Add(new Answer("Ghi chú khác", "", false));
            question.ListAnswer = ListAnswer;
            ListQuestion.Add(question);
            #endregion
            reportBO.ListQuestion = ListQuestion;
            #endregion
            ListReport.Add(reportBO);
            #region  Chỗ ở và mặt hàng phi lương thực
            reportBO = new ReportBO();
            reportBO.Title = "Chỗ ở và mặt hàng phi lương thực";
            ListQuestion = new List<Question>();
            #region Câu 53
            question = new Question();
            question.QuestionNumber = 53;
            question.Title = "Các loại hình nhà ở địa phương là gì?";
            ListAnswer = new List<Answer>();
            ListAnswer.Add(new Answer("", "", false));
            question.ListAnswer = ListAnswer;
            ListQuestion.Add(question);
            #endregion
            #region Câu 54
            question = new Question();
            question.QuestionNumber = 54;
            question.Title = "Kết cấu nhà phổ biến ở cộng đồng như thế nào?";
            ListAnswer = new List<Answer>();
            ListAnswer.Add(new Answer("", "", false));
            question.ListAnswer = ListAnswer;
            ListQuestion.Add(question);
            #endregion
            #region Câu 55
            question = new Question();
            question.QuestionNumber = 55;
            question.Title = "Thiệt hại về nhà sau bão (chỉ tính thiệt hại nhà ở chính).?";
            ListAnswer = new List<Answer>();
            ListAnswer.Add(new Answer("Nhà sập đổ hoàn toàn", "", true));
            ListAnswer.Add(new Answer("Nhà bị cuốn trôi", "", true));
            ListAnswer.Add(new Answer("Nhà bị hư hỏng nặng không thể sửa chữa", "", true));
            ListAnswer.Add(new Answer("Nhà bị tốc mái", "", true));
            question.ListAnswer = ListAnswer;
            ListQuestion.Add(question);
            #endregion
            #region Câu 56
            question = new Question();
            question.QuestionNumber = 56;
            question.Title = "Người dân đã ứng phó thế nào với thiệt hại về nhà (đánh dấu “v” vào các ô phù hợp)";
            ListAnswer = new List<Answer>();
            ListAnswer.Add(new Answer("Ở nhờ nhà người quen", "", true));
            ListAnswer.Add(new Answer("Ở nơi sơ tán", "", true));
            ListAnswer.Add(new Answer("Dựng tạm nhà để ở", "", true));
            ListAnswer.Add(new Answer("Khác(Nêu rõ)", "", true));
            question.ListAnswer = ListAnswer;
            ListQuestion.Add(question);
            #endregion
            #region Câu 57
            question = new Question();
            question.QuestionNumber = 57;
            question.Title = "Các mặt hàng vật liệu xây dựng (bao gồm cả tấm bạt nhựa…) có bán sẵn ở địa phương hay không? (đánh dấu “X” vào ô phù hợp)";
            ListAnswer = new List<Answer>();
            ListAnswer.Add(new Answer("Trước thảm họa", "", true));
            ListAnswer.Add(new Answer("Sau thảm họa", "", true));
            question.ListAnswer = ListAnswer;
            ListQuestion.Add(question);
            #endregion
            #region Câu 58
            question = new Question();
            question.QuestionNumber = 58;
            question.Title = "Sau bão, giá các mặt hàng vật liệu xây dựng có tăng không?";
            ListAnswer = new List<Answer>();
            ListAnswer.Add(new Answer("Không", "", true));
            ListAnswer.Add(new Answer("Có (nếu có, ghi rõ tỉ lệ % biến động và lý do):", "", true));
            question.ListAnswer = ListAnswer;
            ListQuestion.Add(question);
            #endregion
            #region Câu 59
            question = new Question();
            question.QuestionNumber = 59;
            question.Title = "Sau bão, giá các mặt hàng vật liệu xây dựng có tăng không?";
            ListAnswer = new List<Answer>();
            ListAnswer.Add(new Answer("Chưa", "", true));
            ListAnswer.Add(new Answer("Có (Nếu có trả lời câu 59c) Nêu cụ thể can thiệp gì?", "", true));
            ListAnswer.Add(new Answer("Do ai thực hiện", "", false));
            question.ListAnswer = ListAnswer;
            ListQuestion.Add(question);
            #endregion
            #region Câu 60
            question = new Question();
            question.QuestionNumber = 60;
            question.Title = "Người dân có bị ảnh hưởng về đồ dùng gia đình (chăn, màn, dụng cụ nấu ăn)?";
            ListAnswer = new List<Answer>();
            ListAnswer.Add(new Answer("Không", "", true));
            ListAnswer.Add(new Answer("Có", "", true));
            question.ListAnswer = ListAnswer;
            ListQuestion.Add(question);
            #endregion
            #region Câu 61
            question = new Question();
            question.QuestionNumber = 61;
            question.Title = "Những người bị ảnh hưởng đã ứng phó như thế nào?";
            ListAnswer = new List<Answer>();
            ListAnswer.Add(new Answer("", "", false));
            question.ListAnswer = ListAnswer;
            ListQuestion.Add(question);
            #endregion
            #region Câu 62
            question = new Question();
            question.QuestionNumber = 62;
            question.Title = "Những người bị ảnh hưởng hiện có đồ dùng gia đình để sử dụng không?";
            ListAnswer = new List<Answer>();
            ListAnswer.Add(new Answer("Không", "", true));
            ListAnswer.Add(new Answer("Có", "", true));
            question.ListAnswer = ListAnswer;
            ListQuestion.Add(question);
            #endregion
            #region Câu 63
            question = new Question();
            question.QuestionNumber = 63;
            question.Title = "Đã hoặc sẽ có can thiệp gì về dụng cụ/đồ dùng gia đình chưa?";
            ListAnswer = new List<Answer>();
            ListAnswer.Add(new Answer("Chưa", "", true));
            ListAnswer.Add(new Answer("Có (Nếu có trả lời câu 63c) Nêu cụ thể can thiệp gì ?", "", true));
            ListAnswer.Add(new Answer("Do ai thực hiện", "", false));
            question.ListAnswer = ListAnswer;
            ListQuestion.Add(question);
            #endregion
            #region Câu 64
            question = new Question();
            question.QuestionNumber = 64;
            question.Title = "Bảng";
            ListAnswer = new List<Answer>();
            ListAnswer.Add(new Answer("Ghi thêm quan sát/phát hiện:", "", false));
            ListAnswer.Add(new Answer("Các thông tin cần kiểm chứng thêm:", "", false));
            ListAnswer.Add(new Answer("Ghi chú khác", "", false));
            question.ListAnswer = ListAnswer;
            ListQuestion.Add(question);
            #endregion

            reportBO.ListQuestion = ListQuestion;
            #endregion
            ListReport.Add(reportBO);
            return ListReport;
        }
        
    }
}
