using Microsoft.VisualStudio.TestTools.UnitTesting;
using S22.Imap.Tests.S22.Imap.Tests;
using System.Collections.Generic;
using System.Linq;

namespace S22.Imap.Tests {
	/// <summary>
	/// Contains unit tests for ImapClient.ListMailboxes
	/// </summary>
	[TestClass]
	public class ImapListTest {
		/// <summary>
		/// Creates an ImapClient instance using a mock stream and
		/// retrieves a list of mailboxes from the (mock) server.
		/// </summary>
		[TestMethod]
		public void ListSelectableMailboxes() {
			string[] expected = new string[] {
				"INBOX",
				"[Gmail]/Όλα τα μηνύματα",
				"[Gmail]/Ανεπιθύμητα",
				"[Gmail]/Απεσταλμένα",
				"[Gmail]/Κάδος απορριμμάτων",
				"[Gmail]/Με αστέρι",
				"[Gmail]/Πρόχειρα",
				"[Gmail]/Σημαντικά"
			};

			using(ImapClient client = new ImapClient(
				new MockStream(Resources.ImapListResponse))) {
				IEnumerable<string> list = client.ListMailboxes();
				Assert.IsTrue(expected.SequenceEqual(list));
			}
		}
	}
}
